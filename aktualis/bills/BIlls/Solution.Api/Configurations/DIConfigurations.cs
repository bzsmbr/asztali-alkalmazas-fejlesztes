using Solution.Services;

namespace Solution.Api.Configurations;

public static class DIConfigurations
{
    public static WebApplicationBuilder ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddTransient<IBillService, BillService>();

        builder.Services.AddTransient<IItemService, ItemService>();

        return builder;
    }
}
