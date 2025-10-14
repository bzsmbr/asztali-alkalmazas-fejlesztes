namespace Solution.Core.Interfaces;

public interface IPhoneService
{
    Task<ErrorOr<PhoneModel>> CreateAsync(PhoneModel model);
    Task<ErrorOr<Success>> UpdateAsync(PhoneModel model);
    Task<ErrorOr<Success>> DeleteAsync(string id);
    Task<ErrorOr<PhoneModel>> GetByIdAsync(string id);
    Task<ErrorOr<List<PhoneModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<PhoneModel>>> GetPagedAsync(int page = 0);
}
