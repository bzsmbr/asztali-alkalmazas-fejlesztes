namespace Solution.DesktopApp.ViewModels;

public partial class AddTypeViewModel(
    AppDbContext dbContext,
    ITypeService typeService) : TypeModel
{
    public IAsyncRelayCommand SubmitCommand => new AsyncRelayCommand(OnSaveAsync);
    public ICommand ValidateCommand => new Command<string>(OnValidateAsync);
    private TypeModelValidator validator => new TypeModelValidator();
    [ObservableProperty]
    private ValidationResult validationResult = new ValidationResult();
    private async void OnValidateAsync(string propertyName)
    {
        var result = await validator.ValidateAsync(this, options => options.IncludeProperties(propertyName));

        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == propertyName));
        ValidationResult.Errors.Remove(ValidationResult.Errors.FirstOrDefault(x => x.PropertyName == TypeModelValidator.GlobalProperty));

        ValidationResult.Errors.AddRange(result.Errors);

        OnPropertyChanged(nameof(propertyName));
    }
    private void ClearForm()
    {
        this.Name = null;
    }

    private async Task OnSaveAsync()
    {
        this.ValidationResult = await validator.ValidateAsync(this);

        if (!ValidationResult.IsValid)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Save failed", "OK");
            return;
        }

        var result = await typeService.CreateAsync(this);
        var message = result.IsError ? result.FirstError.Description : "Type saved.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            ClearForm();
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}
