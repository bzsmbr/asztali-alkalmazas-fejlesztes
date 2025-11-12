namespace Solution.Core.Interfaces;

public interface IBillService
{
    Task<ErrorOr<BillModel>> CreateAsync(BillModel model);
    Task<ErrorOr<Success>> UpdateAsync(BillModel model);
    Task<ErrorOr<Success>> DeleteAsync(int billId);
    Task<ErrorOr<BillModel>> GetByIdAsync(int billId);
    Task<ErrorOr<List<BillModel>>> GetAllAsync();
    Task<ErrorOr<PaginationModel<BillModel>>> GetPagedAsync(int page = 0);

}
