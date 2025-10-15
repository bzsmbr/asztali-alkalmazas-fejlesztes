namespace Solution.DesktopApp.Components;

public partial class ManufacturerListComponent : ContentView
{
    public static readonly BindableProperty ManufacturerProperty = BindableProperty.Create(
         propertyName: nameof(Manufacturer),
         returnType: typeof(ManufacturerModel),
         declaringType: typeof(ManufacturerListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public ManufacturerModel Manufacturer
    {
        get => (ManufacturerModel)GetValue(ManufacturerProperty);
        set => SetValue(ManufacturerProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
         propertyName: nameof(DeleteCommand),
         returnType: typeof(IAsyncRelayCommand),
         declaringType: typeof(ManufacturerListComponent),
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
         declaringType: typeof(ManufacturerListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.TwoWay
        );

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    public ManufacturerListComponent()
    {
        InitializeComponent();
    }

    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            { "Manufacturer", this.Manufacturer}
        };

        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(AddManufacturerView.Name, navigationQueryParameter);
    }
}