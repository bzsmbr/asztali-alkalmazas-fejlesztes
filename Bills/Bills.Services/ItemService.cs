namespace Bills.Services;
public class ItemService(AppDbContext dbContext) : IItemService
{
    public async Task<ErrorOr<ItemModel>> CreateAsync(ItemModel item)
    {
        //nincs ellenorzes h letezik-e
        var newItem = item.ToEntity();

        await dbContext.Items.AddAsync(newItem);
        await dbContext.SaveChangesAsync();

        return new ItemModel(newItem);
    }

    public async Task<ErrorOr<Success>> DeleteAsync(ItemModel item)
    {
        var result = await dbContext.Items.AsNoTracking()
                                          .Where(x => x == item.ToEntity())
                                          .ExecuteDeleteAsync();

        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<List<ItemModel>>> GetAllAsync() => await dbContext.Items.Select(x => new ItemModel(x))
                                                                                      .ToListAsync();


    public async Task<ErrorOr<ItemModel>> GetByIdAsync(int id)
    {
        var item = await dbContext.Items.FirstOrDefaultAsync(x => x.Id == id);
        if(item is null)
        {
            return Error.NotFound(description: "Item not found!");
        }
        return new ItemModel(item);
    }

    public async Task<ErrorOr<Success>> UpdateAsync(ItemModel item)
    {
        var result = await dbContext.Items.AsNoTracking()
                                          .Where(x => x.Id == item.Id)
                                          .ExecuteUpdateAsync(x => x.SetProperty(p => p.Name, item.Name)
                                                                    .SetProperty(p => p.Price, item.Price)
                                                                    .SetProperty(p => p.Amount, item.Amount));
        return result > 0 ? Result.Success : Error.NotFound();
    }
}