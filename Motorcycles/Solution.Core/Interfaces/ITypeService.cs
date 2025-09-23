
namespace Solution.Core.Interfaces;

public interface ITypeService
{
    Task<ErrorOr<TypeModel>> CreateAsync(TypeModel model);
}
