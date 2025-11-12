using System;

namespace Solution.Core.Interfaces;

public interface IItemService
{
    Task<ErrorOr<ItemModel>> CreateAsync(ItemModel model);
    Task<ErrorOr<Success>> UpdateAsync(ItemModel model);
    Task<ErrorOr<Success>> DeleteAsync(int itemId);
    Task<ErrorOr<ItemModel>> GetByIdAsync(int itemId);
    Task<ErrorOr<List<ItemModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<ItemModel>>> GetPagedAsync(int page = 0);
}


