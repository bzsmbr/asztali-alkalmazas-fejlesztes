namespace Solution.DesktopApp.Configurations;

public static class ConfigureDI
{
    public static MauiAppBuilder UseDIConfiguration(this MauiAppBuilder builder)
    {
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MotorcycleListViewModel>();
        builder.Services.AddTransient<CreateOrEditMotorcycleViewModel>();
        builder.Services.AddTransient<AddManufacturerViewModel>();
        builder.Services.AddTransient<AddTypeViewModel>();

        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<MotorcycleListView>();
        builder.Services.AddTransient<CreateOrEditMotorcycleView>();
        builder.Services.AddTransient<AddManufacturerView>();
        builder.Services.AddTransient<AddTypeView>();

        builder.Services.AddScoped<IGoogleDriveService, GoogleDriveService>();
        builder.Services.AddTransient<IMotorcycleService, MotorcycleService>();
        builder.Services.AddTransient<IManufacturerService, ManufacturerService>();
        builder.Services.AddTransient<ITypeService, TypeService>();
        builder.Services.AddTransient<TypeListViewModel>();

        return builder;
    }
}
