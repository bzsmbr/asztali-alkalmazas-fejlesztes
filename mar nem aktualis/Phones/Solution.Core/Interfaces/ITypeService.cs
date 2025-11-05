namespace Solution.Core.Interfaces;

public interface ITypeService
{
    Task<ErrorOr<TypeModel>> CreateAsync(TypeModel model);
    Task<ErrorOr<Success>> UpdateAsync(TypeModel model);
    Task<ErrorOr<Success>> DeleteAsync(int typeId);
    Task<ErrorOr<TypeModel>> GetByIdAsync(int typeId);
    Task<ErrorOr<List<TypeModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<TypeModel>>> GetPagedAsync(int page = 0);
}


