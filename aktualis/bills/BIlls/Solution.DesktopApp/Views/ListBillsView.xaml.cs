using Bills.DesktopApp.ViewModels;

namespace Bills.DesktopApp.Views;

public partial class ListBillsView : ContentPage
{
	public ListBillsViewModel ViewModel => this.BindingContext as ListBillsViewModel;
	public static string Name => nameof(ListBillsView);
    public ListBillsView(ListBillsViewModel viewModel)
	{
		this.BindingContext = viewModel;
        InitializeComponent();
	}
}