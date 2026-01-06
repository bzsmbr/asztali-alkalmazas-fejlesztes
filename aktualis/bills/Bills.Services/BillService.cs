namespace Bills.Services;
public class BillService(AppDbContext dbContext, IItemService itemService) : IBillService
{
    private const int ROW_COUNT = 20;

    public async Task<ErrorOr<BillModel>> CreateAsync(BillModel bill)
    {
        bool exists = await dbContext.Bills.AnyAsync(x => x.Number == bill.Number);
        if (exists)
        {
            return Error.Conflict(description: "Bill already exists");
        }

        foreach (var item in bill.Items)
        {
            item.Id = 0;
        }
        var newBill = bill.ToEntity();
        await dbContext.Bills.AddAsync(newBill);
        await dbContext.SaveChangesAsync();

        return new BillModel(newBill);
    }

    public async Task<ErrorOr<Success>> DeleteAsync(int id)
    {
        var result = await dbContext.Bills.AsNoTracking()
                                          .Where(x => x.Id == id)
                                          .ExecuteDeleteAsync();
        return result > 0 ? Result.Success : Error.NotFound();
    }

    public async Task<ErrorOr<List<BillModel>>> GetAllAsync() => await dbContext.Bills.Select(x => new BillModel(x))
                                                                                      .ToListAsync();

    public async Task<ErrorOr<BillModel>> GetByIdAsync(int id)
    {
        var bill = await dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);
        if(bill is null)
        {
            return Error.NotFound(description: "Bill not found!");
        }
        return new BillModel(bill);
    }

    public async Task<ErrorOr<Success>> UpdateAsync(BillModel bill)
    {
        var existingBill = await dbContext.Bills.Include(b => b.Items)
                                                .FirstOrDefaultAsync(b => b.Id == bill.Id);

        if (existingBill is null)
        {
            return Error.NotFound();
        }

        existingBill.Number = bill.Number;
        existingBill.Date = bill.Date;

        var incomingIds = bill.Items.Select(i => i.Id);

        var toRemove = existingBill.Items.Where(i => incomingIds.Contains(i.Id) == false)
                                         .ToList();

        foreach (var item in toRemove)
        {
            var exists = await dbContext.Items.AnyAsync(x => x.Id == item.Id);
            if (exists)
                dbContext.Remove(item);
        }

        foreach (var incoming in bill.Items)
        {
            var existingItem = existingBill.Items.FirstOrDefault(i => i.Id == incoming.Id);

            if (existingItem != null)
            {
                existingItem.Name = incoming.Name;
                existingItem.Price = incoming.Price;
                existingItem.Amount = incoming.Amount;
            }
            else
            {
                existingBill.Items.Add(new ItemEntity
                {
                    BillId = bill.Id,
                    Name = incoming.Name,
                    Price = incoming.Price,
                    Amount = incoming.Amount
                });
            }
        }

        await dbContext.SaveChangesAsync();
        return Result.Success;
    }


    public async Task<ErrorOr<PaginationModel<BillModel>>> GetPagedAsync(int page = 0)
    {
        page = page <= 0 ? 1 : page - 1;

        var bills = await dbContext.Bills.AsNoTracking()
                                         .Include(x => x.Items)
                                         .Skip(page * ROW_COUNT)
                                         .Take(ROW_COUNT)
                                         .Select(x => new BillModel(x))
                                         .ToListAsync();

        var paginationModel = new PaginationModel<BillModel>
        {
            Items = bills,
            Count = await dbContext.Bills.CountAsync()
        };

        return paginationModel;
    }
}
