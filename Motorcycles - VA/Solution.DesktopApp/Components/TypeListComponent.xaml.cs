namespace Solution.DesktopApp.Components;

public partial class TypeListComponent : ContentView
{
    public static readonly BindableProperty TypeProperty = BindableProperty.Create(
         propertyName: nameof(Type),
         returnType: typeof(TypeModel),
         declaringType: typeof(TypeListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.OneWay
    );

    public TypeModel Type
    {
        get => (TypeModel)GetValue(TypeProperty);
        set => SetValue(TypeProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
         propertyName: nameof(DeleteCommand),
         returnType: typeof(IAsyncRelayCommand),
         declaringType: typeof(TypeListComponent),
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
         declaringType: typeof(TypeListComponent),
         defaultValue: null,
         defaultBindingMode: BindingMode.TwoWay
        );

    public string CommandParameter
    {
        get => (string)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public IAsyncRelayCommand EditCommand => new AsyncRelayCommand(OnEditAsync);

    public TypeListComponent()
	{
		InitializeComponent();
	}

    private async Task OnEditAsync()
    {
        ShellNavigationQueryParameters navigationQueryParameter = new ShellNavigationQueryParameters
        {
            { "Type", this.Type}
        };

        Shell.Current.ClearNavigationStack();
        await Shell.Current.GoToAsync(AddTypeView.Name, navigationQueryParameter);
    }
}