namespace Solution.Services;

public class ManufacturerService(AppDbContext dbContext) : IManufacturerService
{
    public async Task<ErrorOr<ManufacturerModel>> CreateAsync(ManufacturerModel model)
    {
        bool exists = await dbContext.Manufacturers.AnyAsync(x => x.Name == model.Name);

        if (exists)
        {
            return Error.Conflict(description: "Manufacturer already exists!");
        }

        var manufacturer = model.ToEntity();

        await dbContext.Manufacturers.AddAsync(manufacturer);
        await dbContext.SaveChangesAsync();

        return new ManufacturerModel(manufacturer);
    }
}
