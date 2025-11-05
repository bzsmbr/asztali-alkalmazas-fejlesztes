namespace Solution.DesktopApp.Views;

public partial class ManufacturerListView : ContentPage
{
    public ManufacturerListViewModel ViewModel => this.BindingContext as ManufacturerListViewModel; //

    public static string Name => nameof(ManufacturerListView); //

    public ManufacturerListView(ManufacturerListViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();
    }
}