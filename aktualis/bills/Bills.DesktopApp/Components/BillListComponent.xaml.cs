namespace Bills.DesktopApp.Components;

public partial class BillListComponent : ContentView
{
    public BillModel Bill
    {
        get => (BillModel)GetValue(BillProperty);
        set => SetValue(BillProperty, value);
    }

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IAsyncRelayCommand DeleteCommand
    {
        get => (IAsyncRelayCommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            { "Bill", this.Bill}
        };

        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditBillView.Name, navigationQueryParameter);
    }

    #region Bindable Properties

    public static readonly BindableProperty BillProperty = BindableProperty.Create(
        propertyName: nameof(Bill),
        returnType: typeof(BillModel),
        declaringType: typeof(BillListComponent),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
        propertyName: nameof(DeleteCommand),
        returnType: typeof(IAsyncRelayCommand),
        declaringType: typeof(BillListComponent),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay
    );

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
        propertyName: nameof(CommandParameter),
        returnType: typeof(string),
        declaringType: typeof(BillListComponent),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay
    );

    #endregion

    public BillListComponent()
	{
		InitializeComponent();
	}
}