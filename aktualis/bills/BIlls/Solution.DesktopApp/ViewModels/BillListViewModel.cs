using Bills.Core.Interfaces;
using Bills.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class BillListViewModel(IBillService billService)
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
    private ObservableCollection<BillModel> bills;

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

    private async Task OnDisappearingAsync()
    { }

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

    private async Task OnDeleteAsync(int id)
    {
        var result = await billService.DeleteAsync(id);

        var message = result.IsError ? result.FirstError.Description : "Bill deleted.";
        var title = result.IsError ? "Error" : "Information";

        if (!result.IsError)
        {
            var bill = bills.SingleOrDefault(x => x.Id == id);
            bills.Remove(bill);

            if (bills.Count == 0)
            {
                await LoadBillsAsync();
            }
        }

        await Application.Current.MainPage.DisplayAlert(title, message, "OK");
    }
}
