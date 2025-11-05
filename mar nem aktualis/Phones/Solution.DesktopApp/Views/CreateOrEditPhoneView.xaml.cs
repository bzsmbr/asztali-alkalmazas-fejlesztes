namespace Solution.DesktopApp.Views;

public partial class CreateOrEditPhoneView : ContentPage
{
	public CreateOrEditPhoneViewModel ViewModel => this.BindingContext as CreateOrEditPhoneViewModel;

	public static string Name => nameof(CreateOrEditPhoneView);

    public CreateOrEditPhoneView(CreateOrEditPhoneViewModel viewModel)
	{
		this.BindingContext = viewModel;

		InitializeComponent();
	}
}