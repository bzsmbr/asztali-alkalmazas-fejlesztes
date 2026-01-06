using Bills.Core.Models;
using Bills.DesktopApp.Extensions;
using CommunityToolkit.Mvvm.Input;

namespace Bills.DesktopApp.Components;

public partial class ItemListComponent : ContentView
{
    public ItemModel Item
    {
        get => (ItemModel)GetValue(ItemProperty);
        set => SetValue(ItemProperty, value);
    }

	public string CommandParameter
	{
		get => (string)GetValue(CommandParameterProperty);
		set => SetValue(CommandParameterProperty, value);
	}

    public IAsyncRelayCommand DeleteCommand
	{
		get =>(IAsyncRelayCommand)GetValue(DeleteCommandProperty);
		set => SetValue(DeleteCommandProperty, value);
    }

    public IAsyncRelayCommand EditCommand
    {
        get => (IAsyncRelayCommand)GetValue(EditCommandProperty);
        set => SetValue(EditCommandProperty, value);
    }

    #region Bindable Properties

    public static readonly BindableProperty ItemProperty = BindableProperty.Create(
		propertyName: nameof(Item),
		returnType: typeof(ItemModel),
		declaringType: typeof(ItemListComponent),
		defaultValue: null,
		defaultBindingMode: BindingMode.OneWay
    );

	public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
		propertyName: nameof(DeleteCommand),
		returnType: typeof(IAsyncRelayCommand),
		declaringType: typeof(ItemListComponent),
		defaultValue: null,
		defaultBindingMode: BindingMode.OneWay
    );

	public static readonly BindableProperty EditCommandProperty = BindableProperty.Create(
		propertyName: nameof(EditCommand),
		returnType: typeof(IAsyncRelayCommand),
		declaringType: typeof(ItemListComponent),
		defaultValue: null,
		defaultBindingMode: BindingMode.OneWay
	);

    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
		propertyName: nameof(CommandParameter),
		returnType: typeof(string),
		declaringType: typeof(ItemListComponent),
		defaultValue: null,
		defaultBindingMode: BindingMode.TwoWay
	);

    #endregion

    public ItemListComponent()
	{
		InitializeComponent();
	}
}