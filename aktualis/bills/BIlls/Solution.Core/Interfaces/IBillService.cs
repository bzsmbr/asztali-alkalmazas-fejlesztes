using Bills.Core.Models;

namespace Bills.Core.Interfaces;
public interface IBillService
{
    Task<ErrorOr<List<BillModel>>> GetAllAsync();
    Task<ErrorOr<BillModel>> GetByIdAsync(int id);
    Task<ErrorOr<BillModel>> CreateAsync(BillModel bill);
    Task<ErrorOr<Success>> UpdateAsync(BillModel bill);
    Task<ErrorOr<Success>> DeleteAsync(int id);
    Task<ErrorOr<PaginationModel<BillModel>>> GetPagedAsync(int page = 0);
}
