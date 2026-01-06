namespace Bills.DesktopApp;
public partial class AppShell : Shell
{
    public AppShellViewModel ViewModel => this.BindingContext as AppShellViewModel;
    public static string Name => nameof(AppShell);
    public AppShell()
    {
        this.BindingContext = new AppShellViewModel();

        InitializeComponent();

        ConfigureRoutes();
    }
    private static void ConfigureRoutes()
    {
        Routing.RegisterRoute(CreateOrEditBillView.Name, typeof(CreateOrEditBillView));
        Routing.RegisterRoute(ListBillsView.Name, typeof(ListBillsView));
    }
}
