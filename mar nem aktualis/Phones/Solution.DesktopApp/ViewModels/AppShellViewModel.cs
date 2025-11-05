using CommunityToolkit.Mvvm.Input;

namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);

    public IAsyncRelayCommand AddNewPhoneCommand => new AsyncRelayCommand(OnAddNewPhoneAsync);
    public IAsyncRelayCommand ListAllPhonesCommand => new AsyncRelayCommand(OnListAllPhonesAsync);
    public IAsyncRelayCommand AddNewManufacturersCommand => new AsyncRelayCommand(OnAddNewManufacturersAsync);

    public IAsyncRelayCommand ListManufacturersCommand => new AsyncRelayCommand(OnListAllManufacturersAsync);
    public IAsyncRelayCommand AddNewTypesCommand => new AsyncRelayCommand(OnAddNewTypesAsync);

    public IAsyncRelayCommand ListTypesCommand => new AsyncRelayCommand(OnListAllTypesAsync);




    private async Task OnExitAsync() => Application.Current.Quit();

    private async Task OnAddNewPhoneAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditPhoneView.Name);
    }
    private async Task OnListAllPhonesAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(PhoneListView.Name);
    }
    private async Task OnAddNewManufacturersAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(AddManufacturerView.Name);
    }
    private async Task OnAddNewTypesAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(AddTypeView.Name);
    }

    private async Task OnListAllTypesAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(TypeListView.Name);
    }

    private async Task OnListAllManufacturersAsync() //
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(ManufacturerListView.Name);
    }
}
