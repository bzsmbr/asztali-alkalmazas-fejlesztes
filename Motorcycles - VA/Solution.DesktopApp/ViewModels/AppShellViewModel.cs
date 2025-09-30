using CommunityToolkit.Mvvm.Input;

namespace Solution.DesktopApp.ViewModels;

[ObservableObject]
public partial class AppShellViewModel
{
    public IAsyncRelayCommand ExitCommand => new AsyncRelayCommand(OnExitAsync);

    public IAsyncRelayCommand AddNewMotorcycleCommand => new AsyncRelayCommand(OnAddNewMotorcycleAsync);
    public IAsyncRelayCommand ListAllMotorcyclesCommand => new AsyncRelayCommand(OnListAllMotorcyclesAsync);
    public IAsyncRelayCommand AddNewManufacturersCommand => new AsyncRelayCommand(OnAddNewManufacturersAsync);

    public IAsyncRelayCommand ListManufacturersCommand => new AsyncRelayCommand(OnListAllManufacturersAsync);
    public IAsyncRelayCommand AddNewTypesCommand => new AsyncRelayCommand(OnAddNewTypesAsync);

    public IAsyncRelayCommand ListTypesCommand => new AsyncRelayCommand(OnListAllTypesAsync);




    private async Task OnExitAsync() => Application.Current.Quit();

    private async Task OnAddNewMotorcycleAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditMotorcycleView.Name);
    }
    private async Task OnListAllMotorcyclesAsync()
    {
        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(MotorcycleListView.Name);
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
