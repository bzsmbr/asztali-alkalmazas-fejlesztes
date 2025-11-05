namespace Solution.DesktopApp.Components;

public partial class PhoneListComponent : ContentView
{
    public static readonly BindableProperty PhoneProperty = BindableProperty.Create(
         propertyName: nameof(Phone),
         returnType: typeof(PhoneModel),
         declaringType: typeof(PhoneListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public PhoneModel Phone
    {
        get => (PhoneModel)GetValue(PhoneProperty);
        set => SetValue(PhoneProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
         propertyName: nameof(DeleteCommand),
         returnType: typeof(IAsyncRelayCommand),
         declaringType: typeof(PhoneListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public IAsyncRelayCommand DeleteCommand
    {
        get => (IAsyncRelayCommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
         propertyName: nameof(CommandParameter),
         returnType: typeof(string),
         declaringType: typeof(PhoneListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.TwoWay
        );

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    public PhoneListComponent()
	{
		InitializeComponent();
	}

    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            { "Phone", this.Phone}
        };

        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(CreateOrEditPhoneView.Name, navigationQueryParameter);
    }
}