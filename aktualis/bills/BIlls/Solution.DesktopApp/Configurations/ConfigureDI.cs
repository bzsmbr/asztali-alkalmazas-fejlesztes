namespace Bills.DesktopApp.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        //VIEWS
        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<CreateOrEditBillView>();
        builder.Services.AddTransient<ListBillsView>();

        //VIEWMODELS
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<CreateOrEditBillViewModel>();
        builder.Services.AddTransient<ListBillsViewModel>();

        //SERVICES
        builder.Services.AddTransient<IItemService, ItemService>();
        builder.Services.AddTransient<IBillService, BillService>();
    
        return builder;
    }
}
