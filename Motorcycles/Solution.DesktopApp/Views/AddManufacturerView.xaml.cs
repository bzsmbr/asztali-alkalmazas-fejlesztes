namespace Solution.DesktopApp.Views;

public partial class AddManufacturerView : ContentPage
{
	public AddManufacturerViewModel ViewModel => this.BindingContext as AddManufacturerViewModel;

	public static string Name => nameof(AddManufacturerView);
	public AddManufacturerView(AddManufacturerViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}