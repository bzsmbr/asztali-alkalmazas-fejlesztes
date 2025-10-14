namespace Solution.DesktopApp.Views;

public partial class PhoneListView : ContentPage
{
	public PhoneListViewModel ViewModel => this.BindingContext as PhoneListViewModel;

	public static string Name => nameof(PhoneListView);

    public PhoneListView(PhoneListViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}