namespace Bills.DesktopApp.ViewModels;

[ObservableObject]
public partial class ListBillsViewModel(IBillService billService)
{
    public IAsyncRelayCommand AppearingCommand => new AsyncRelayCommand(OnAppearingAsync);

    public ICommand PreviousPageCommand { get; private set; }
    public ICommand NextPageCommand { get; private set; }

    public IAsyncRelayCommand DeleteCommand => new AsyncRelayCommand<int>((id) => OnDeleteAsync(id));

    [ObservableProperty]
    public ObservableCollection<BillModel> bills;

    private int page = 1;
    private bool isLoading = false;
    private bool hasNextPage = false;
    private int numberOfBillsInDB = 0;

    private async Task OnAppearingAsync()
    {
        PreviousPageCommand = new Command(async () => await OnPreviousPageAsync(), () => page > 1 && !isLoading);
        NextPageCommand = new Command(async () => await OnNextPageAsync(), () => !isLoading && hasNextPage);

        await LoadBillsAsync();
    }

    private async Task LoadBillsAsync()
    {
        isLoading = true;

        var result = await billService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Bills not loaded!", "OK");
            return;
        }

        Bills = new ObservableCollection<BillModel>(result.Value.Items);
        numberOfBillsInDB = result.Value.Count;

        hasNextPage = numberOfBillsInDB - (page * 10) > 0;
        isLoading = false;

        ((Command)PreviousPageCommand).ChangeCanExecute();
        ((Command)NextPageCommand).ChangeCanExecute();
    }

    private async Task OnPreviousPageAsync()
    {
        if (isLoading) return;

        page = page <= 1 ? 1 : --page;
        await LoadBillsAsync();
    }

    private async Task OnNextPageAsync()
    {
        if (isLoading) return;

        page++;
        await LoadBillsAsync();
    }

    private async Task OnDeleteAsync(int id)
    {
        var result = await billService.DeleteAsync(id);

        var message = result.IsError ? result.FirstError.Description : "Bill deleted.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            var bill = Bills.SingleOrDefault(x => x.Id == id);
            Bills.Remove(bill);
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}

