using Solution.Core.Interfaces;

namespace Solution.DesktopApp.ViewModels;

public partial class CreateOrEditPhoneViewModel(
    AppDbContext dbContext,
    IPhoneService phoneService,
    IGoogleDriveService googleDriveService) : PhoneModel, IQueryAttributable
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingkAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    #region validation
    public ICommand ValidateCommand => new Command<string>(OnValidateAsync);
    #endregion

    #region event commands
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSubmitAsync);
    public IAsyncRelayCommand ImageSelectCommand => new AsyncRelayCommand(OnImageSelectAsync);
    #endregion

    private PhoneModelValidator validator => new PhoneModelValidator(null);

    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();

    private delegate Task ButtonActionDelagate();
    private ButtonActionDelagate asyncButtonAction;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private IList<ManufacturerModel> manufacturers = [];

    [ObservableProperty]
    private IList<TypeModel> types = [];

    [ObservableProperty]
    private IList<int> storageInGB = [64, 128, 256, 512, 1024, 2048];

    [ObservableProperty]
    private ImageSource image;

    private FileResult selectedFile = null;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        await Task.Run(LoadManufacturersAsync);
        await Task.Run(LoadTypesAsync);

        bool hasValue = query.TryGetValue("Phone", out object result);

        if(!hasValue)
        {
            asyncButtonAction = OnSaveAsync;
            Title = "Add new  phone";
            return;
        }

        PhoneModel phone = result as PhoneModel;

        this.Id = phone.Id;
        this.Manufacturer = phone.Manufacturer;
        this.Type = phone.Type;
        this.Model = phone.Model;
        this.ReleaseYear = phone.ReleaseYear;
        this.StorageInGB = phone.StorageInGB;
        this.ImageId = phone.ImageId;
        this.WebContentLink = phone.WebContentLink;

        if(!string.IsNullOrEmpty(phone.WebContentLink))
        {
            Image = new UriImageSource
            {
                Uri = new Uri(phone.WebContentLink),
                CacheValidity = new TimeSpan(10, 0, 0, 0)
            };
        }

        asyncButtonAction = OnUpdateAsync;
        Title = "Update phone";
    }

    private async Task OnAppearingkAsync()
    {
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnSubmitAsync() => await asyncButtonAction();

    private async Task OnSaveAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        await UploaImageAsync();

        var result = await phoneService.CreateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Phone saved.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            ClearForm();
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task OnUpdateAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            return;
        }

        await UploaImageAsync();

        var result = await phoneService.UpdateAsync(this);

        var message = result.IsError ? result.FirstError.Description : "Phone updated.";
        var title = result.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }

    private async Task OnImageSelectAsync()
    {
        selectedFile = await FilePicker.PickAsync(new PickOptions
        {
            FileTypes = FilePickerFileType.Images,
            PickerTitle = "Please select the phone image"
        });

        if(selectedFile is null)
        {
            return;
        }

        var stream = await selectedFile.OpenReadAsync();
        Image = ImageSource.FromStream(() => stream);
    }

    private async Task UploaImageAsync()
    {
        if (selectedFile is null)
        {
            return;
        }

        var imageUploadResult = await googleDriveService.UploadFileAsync(selectedFile);

        var message = imageUploadResult.IsError ? imageUploadResult.FirstError.Description : "Phone image uploaded.";
        var title = imageUploadResult.IsError ? "Error" : "Information";

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");

        this.ImageId = imageUploadResult.IsError ? null : imageUploadResult.Value.Id;
        this.WebContentLink = imageUploadResult.IsError ? null : imageUploadResult.Value.WebContentLink;
    }

    private async Task LoadManufacturersAsync()
    {
        Manufacturers = await dbContext.Manufacturers.AsNoTracking()
                                                     .OrderBy(x => x.Name)
                                                     .Select(x => new ManufacturerModel(x))
                                                     .ToListAsync();
    }

    private async Task LoadTypesAsync()
    {
        Types = await dbContext.Types.AsNoTracking()
                                     .OrderBy(x => x.Name)
                                     .Select(x => new TypeModel(x))
                                     .ToListAsync();
    }

    private void ClearForm()
    {
        this.Manufacturer = new ManufacturerModel();
        this.Type = new TypeModel();
        this.Model = null;
        this.ReleaseYear = 0;
        this.StorageInGB = null;

        this.Image = null;
        this.selectedFile = null;
        this.WebContentLink = null;
        this.ImageId = null;
    }

    private async void OnValidateAsync(string propertyName)
    {
        var result = await validator.ValidateAsync(this, options => options.IncludeProperties(propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == PhoneModelValidator.GlobalProperty));
        ValidationResult.Errors.AddRange(result.Errors);

        OnPropertyChanged(nameof(ValidationResult));
    }
}
