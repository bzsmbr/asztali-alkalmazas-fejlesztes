namespace Solution.Services;

public class ItemService(AppDbContext dbContext) : IItemService
{
    private const int ROW_COUNT = 10;

    public async Task<ErrorOr<ItemModel>> CreateAsync(ItemModel model)
    {
        bool exists = await dbContext.Items.AnyAsync(x => x.Name == model.Name &&
                                                          x.UnitPrice == model.UnitPrice &&
                                                          x.Quantity == model.Quantity);


        if (exists)
        {
            return Error.Conflict(description: "Item already exists!");
        }

        var item = model.ToEntity();
        
        await dbContext.Items.AddAsync(item);
        await dbContext.SaveChangesAsync();

        return model;
    }

    public async Task<ErrorOr<Success>> UpdateAsync(ItemModel model)
    {
        var result = await dbContext.Items.AsNoTracking()
                                                .Where(x => x.Id == model.Id)
                                                .ExecuteUpdateAsync(x => x.SetProperty(p => p.Name, model.Name)
                                                                          .SetProperty(p => p.UnitPrice, model.UnitPrice)
                                                                          .SetProperty(p => p.Quantity, model.Quantity));
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int itemId)
    {
        var result = await dbContext.Items.AsNoTracking()
                                                .Where(x => x.Id == itemId)
                                                .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<ItemModel>> GetByIdAsync(int itemId)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == itemId);

        if (item is null)
        {
            return Error.NotFound(description: "Item not found.");
        }

        return new ItemModel(item);
    }

    public async Task<ErrorOr<List<ItemModel>>> GetAllAsync() =>
        await dbContext.Items.AsNoTracking()
                                   .Select(x => new ItemModel(x))
                                   .ToListAsync();

    public async Task<ErrorOr<PaginationModel<ItemModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var items = await dbContext.Items.AsNoTracking()
                                                     .Skip(page * ROW_COUNT)
                                                     .Take(ROW_COUNT)
                                                     .Select(x => new ItemModel(x))
                                                     .ToListAsync();

        var paginationModel = new PaginationModel<ItemModel>
        {
            Items = items,
            Count = await dbContext.Items.CountAsync()
        };

        return paginationModel;
    }
}
