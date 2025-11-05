namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MainView>();

        builder.Services.AddTransient<PhoneListViewModel>();
        builder.Services.AddTransient<PhoneListView>();
        builder.Services.AddTransient<CreateOrEditPhoneViewModel>();
        builder.Services.AddTransient<CreateOrEditPhoneView>();
        builder.Services.AddTransient<IPhoneService, PhoneService>();

        builder.Services.AddTransient<AddManufacturerViewModel>();
        builder.Services.AddTransient<AddManufacturerView>();
        builder.Services.AddTransient<ManufacturerListViewModel>(); //
        builder.Services.AddTransient<IManufacturerService, ManufacturerService>();

        builder.Services.AddTransient<AddTypeViewModel>();
        builder.Services.AddTransient<AddTypeView>();
        builder.Services.AddTransient<TypeListViewModel>();
        builder.Services.AddTransient<ITypeService, TypeService>();

        builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();



       

        return builder;
    }
}
