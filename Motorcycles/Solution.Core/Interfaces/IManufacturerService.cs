
namespace Solution.Core.Interfaces;

public interface IManufacturerService
{
    Task<ErrorOr<ManufacturerModel>> CreateAsync(ManufacturerModel model);
}
