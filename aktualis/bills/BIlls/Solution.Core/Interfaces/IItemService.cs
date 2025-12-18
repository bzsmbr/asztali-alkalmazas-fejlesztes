using Bills.Core.DTO.Requests;
using Bills.Core.Models;

namespace Bills.Core.Interfaces;
public interface IItemService
{
    Task<ErrorOr<List<ItemModel>>> GetAllAsync();
    Task<ErrorOr<ItemModel>> GetByIdAsync(int id);
    Task<ErrorOr<ItemModel>> CreateAsync(ItemModelRequest item);
    Task<ErrorOr<Success>> UpdateAsync(ItemModel item);
    Task<ErrorOr<Success>> DeleteAsync(ItemModel item);
}
