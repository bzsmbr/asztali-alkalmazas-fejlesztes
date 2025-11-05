namespace Solution.Services;

public class PhoneService(AppDbContext dbContext) : IPhoneService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<PhoneModel>> CreateAsync(PhoneModel model)
    {
        bool exists = await dbContext.Phones.AnyAsync(x => x.ManufacturerId == model.Manufacturer.Id &&
                                                                x.Model.ToLower() == model.Model.ToLower().Trim() &&
                                                                x.ReleaseYear == model.ReleaseYear);

        if (exists)
        {
            return Error.Conflict(description: "Phone already exists!");
        }

        var phone = model.ToEntity();
        phone.PublicId = Guid.NewGuid().ToString();
        
        await dbContext.Phones.AddAsync(phone);
        await dbContext.SaveChangesAsync();

        model.Id = phone.PublicId;

        return model;
    }

    public async Task<ErrorOr<Success>> UpdateAsync(PhoneModel model)
    {
        var result = await dbContext.Phones.AsNoTracking()
                                                .Where(x => x.PublicId == model.Id)
                                                .ExecuteUpdateAsync(x => x.SetProperty(p => p.PublicId, model.Id)
                                                                          .SetProperty(p => p.ManufacturerId, model.Manufacturer.Id)
                                                                          .SetProperty(p => p.TypeId, model.Type.Id)
                                                                          .SetProperty(p => p.Model, model.Model)
                                                                          .SetProperty(p => p.ReleaseYear, model.ReleaseYear)
                                                                          .SetProperty(p => p.StorageInGB, model.StorageInGB)
                                                                          .SetProperty(p => p.ImageId, model.ImageId)
                                                                          .SetProperty(p => p.WebContentLink, model.WebContentLink));
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(string id)
    {
        var result = await dbContext.Phones.AsNoTracking()
                                                .Include(x => x.Manufacturer)
                                                .Where(x => x.PublicId == id)
                                                .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<PhoneModel>> GetByIdAsync(string id)
    {
        var phone = await dbContext.Phones.Include(x => x.Manufacturer)
                                                    .FirstOrDefaultAsync(x => x.PublicId == id);

        if (phone is null)
        {
            return Error.NotFound(description: "Phone not found.");
        }

        return new PhoneModel(phone);
    }

    public async Task<ErrorOr<List<PhoneModel>>> GetAllAsync() =>
        await dbContext.Phones.AsNoTracking()
                                   .Include(x => x.Manufacturer)
                                   .Select(x => new PhoneModel(x))
                                   .ToListAsync();

    public async Task<ErrorOr<PaginationModel<PhoneModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var phone = await dbContext.Phones.AsNoTracking()
                                                     .Include(x => x.Manufacturer)
                                                     .Include(x => x.Type)
                                                     .Skip(page * ROW_COUNT)
                                                     .Take(ROW_COUNT)
                                                     .Select(x => new PhoneModel(x))
                                                     .ToListAsync();

        var paginationModel = new PaginationModel<PhoneModel>
        {
            Items = phone,
            Count = await dbContext.Phones.CountAsync()
        };

        return paginationModel;
    }
}
