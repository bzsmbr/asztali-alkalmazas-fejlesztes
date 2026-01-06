namespace Bills.Core.Interfaces;
public interface IItemService
{
    Task<ErrorOr<List<ItemModel>>> GetAllAsync();
    Task<ErrorOr<ItemModel>> GetByIdAsync(int id);
    Task<ErrorOr<ItemModel>> CreateAsync(ItemModel item);
    Task<ErrorOr<Success>> UpdateAsync(ItemModel item);
    Task<ErrorOr<Success>> DeleteAsync(ItemModel item);
}
