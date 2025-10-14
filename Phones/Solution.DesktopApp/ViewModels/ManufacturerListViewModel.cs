namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class ManufacturerListViewModel(IManufacturerService manufacturerService)
{
    #region life cycle commands
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);
    public IAsyncRelayCommand DisappearingCommand => new AsyncRelayCommand(OnDisappearingAsync);
    #endregion

    #region paging commands
    public ICommand PreviousPageCommand { get; private set; }
    public ICommand NextPageCommand { get; private set; }
    #endregion

    #region component commands
    public IAsyncRelayCommand DeleteCommand => new AsyncRelayCommand<int>((id) => OnDeleteAsync(id));
    #endregion

    [ObservableProperty]
    private ObservableCollection<ManufacturerModel> manufacturers;

    private int page = 1;
    private bool isLoading = false;
    private bool hasNextPage = false;
    private int numberOfManufacturersInDB = 0;

    private async Task OnAppearingAsync()
    {
        PreviousPageCommand = new Command(async () => await OnPreviousPageAsync(), () => page > 1 && !isLoading);
        NextPageCommand = new Command(async () => await OnNextPageAsync(), () => !isLoading && hasNextPage);

        await LoadMTypesAsync();
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnPreviousPageAsync()
    {
        if (isLoading) return;

        page = page <= 1 ? 1 : --page;
        await LoadMTypesAsync();
    }

    private async Task OnNextPageAsync()
    {
        if (isLoading) return;

        page++;
        await LoadMTypesAsync();
    }

    private async Task LoadMTypesAsync()
    {
        isLoading = true;

        var result = await manufacturerService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Manufacturers not loaded!", "OK");
            return;
        }

        Manufacturers = new ObservableCollection<ManufacturerModel>(result.Value.Items);
        numberOfManufacturersInDB = result.Value.Count;

        hasNextPage = numberOfManufacturersInDB - (page * 10) > 0;
        isLoading = false;

        ((Command)PreviousPageCommand).ChangeCanExecute();
        ((Command)NextPageCommand).ChangeCanExecute();
    }

    private async Task OnDeleteAsync(int id)
    {
        var result = await manufacturerService.DeleteAsync(id);

        var message = result.IsError ? result.FirstError.Description : "Manufacturer deleted.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            var type = manufacturers.SingleOrDefault(x => x.Id == id);
            manufacturers.Remove(type);

            if (manufacturers.Count == 0)
            {
                await LoadMTypesAsync();
            }
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}
