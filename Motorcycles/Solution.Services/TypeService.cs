using Microsoft.EntityFrameworkCore;

namespace Solution.Services;

public class TypeService(AppDbContext dbContext) : ITypeService
{
    public async Task<ErrorOr<TypeModel>> CreateAsync(TypeModel model)
    {
        bool exists = await dbContext.Types.AnyAsync(x => x.Name == model.Name);

        if (exists)
        {
            return Error.Conflict(description: "Type already exists!");
        }

        var type = model.ToEntity();

        await dbContext.Types.AddAsync(type);
        await dbContext.SaveChangesAsync();

        return new TypeModel(type);
    }
}
