using Bills.DesktopApp.ViewModels;

namespace Bills.DesktopApp.Views;

public partial class CreateOrEditBillView : ContentPage
{
	public CreateOrEditBillViewModel ViewModel => this.BindingContext as CreateOrEditBillViewModel;
    public static string Name => nameof(CreateOrEditBillView);
    public CreateOrEditBillView(CreateOrEditBillViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}

    private void BillDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        if (BindingContext is CreateOrEditBillViewModel viewModel)
        {
            viewModel.ValidateCommand.Execute(BillModelValidator.DateProperty);
        }
    }

    private void NumberEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (BindingContext is CreateOrEditBillViewModel viewModel)
        {
            viewModel.ValidateCommand.Execute(BillModelValidator.NumberProperty);
        }
    }

    private void ItemNameEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (BindingContext is CreateOrEditBillViewModel viewModel)
        {
            viewModel.ValidateCommand.Execute(ItemModelValidator.NameProperty);
        }
    }


}