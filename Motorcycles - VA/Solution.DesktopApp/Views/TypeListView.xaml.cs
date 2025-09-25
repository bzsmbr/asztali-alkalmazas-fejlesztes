namespace Solution.DesktopApp.Views;

public partial class TypeListView : ContentPage
{
	public TypeListViewModel ViewModel => this.BindingContext as TypeListViewModel;

	public static string Name => nameof(TypeListView);

    public TypeListView(TypeListViewModel viewModel)
    {
        this.BindingContext = viewModel;

        InitializeComponent();
    }
}