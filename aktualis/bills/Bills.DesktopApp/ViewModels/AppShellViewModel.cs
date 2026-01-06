

using Bills.DesktopApp.Extensions;
using CommunityToolkit.Mvvm.Input;

namespace Bills.DesktopApp.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);
    public IAsyncRelayCommand CreateOrEditBillCommand => new AsyncRelayCommand(OnCreateOrEditBillAsync);
    public IAsyncRelayCommand ListBillsCommand => new AsyncRelayCommand(OnListBillslAsync);


    private async Task OnExitAsync()
    {
        await Task.Delay(1);
        Application.Current.Quit();
    }

    private async Task OnCreateOrEditBillAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(nameof(CreateOrEditBillView));
    }
    private async Task OnListBillslAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(nameof(ListBillsView));
    }
}
