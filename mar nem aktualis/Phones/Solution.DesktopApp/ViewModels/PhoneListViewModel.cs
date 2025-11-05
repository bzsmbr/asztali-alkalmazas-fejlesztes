using Solution.Core.Interfaces;

namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class PhoneListViewModel(IPhoneService phoneService)
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
    public IAsyncRelayCommand DeleteCommand => new AsyncRelayCommand<string>((id) => OnDeleteAsync(id));
    #endregion

    [ObservableProperty]
    private ObservableCollection<PhoneModel> phones;

    private int page = 1;
    private bool isLoading = false;
    private bool hasNextPage = false;
    private int numberOfPhonesInDB = 0;

    private async Task OnAppearingAsync()
    {
        PreviousPageCommand = new Command(async () => await OnPreviousPageAsync(), () => page > 1 && !isLoading);
        NextPageCommand = new Command(async () => await OnNextPageAsync(), () => !isLoading && hasNextPage);

        await LoadPhonesAsync(GetNumberOfPhonesInDB());
    }

    private async Task OnDisappearingAsync()
    { }

    private async Task OnPreviousPageAsync()
    {
        if (isLoading) return;

        page = page <= 1 ? 1 : --page;
        await LoadPhonesAsync(GetNumberOfPhonesInDB());
    }

    private async Task OnNextPageAsync()
    {
        if (isLoading) return;

        page++;
        await LoadPhonesAsync(GetNumberOfPhonesInDB());
    }

    private int GetNumberOfPhonesInDB()
    {
        return numberOfPhonesInDB;
    }

    private async Task LoadPhonesAsync(int numberOfPhonesInDB)
    {
        isLoading = true;

        var result = await phoneService.GetPagedAsync(page);

        if (result.IsError)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Phones not loaded!", "OK");
            return;
        }

        Phones = new ObservableCollection<PhoneModel>(result.Value.Items);
        numberOfPhonesInDB = result.Value.Count;

        hasNextPage = numberOfPhonesInDB - (page * 10) > 0;
        isLoading = false;

        ((Command)PreviousPageCommand).ChangeCanExecute();
        ((Command)NextPageCommand).ChangeCanExecute();
    }

    private async Task OnDeleteAsync(string? id)
    { 
        var result = await phoneService.DeleteAsync(id);

        var message = result.IsError ? result.FirstError.Description : "Phone deleted.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            var phone = phones.SingleOrDefault(x => x.Id == id);
            phones.Remove(phone);

            if(phones.Count == 0)
            {
                await LoadPhonesAsync(GetNumberOfPhonesInDB());
            }
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}
