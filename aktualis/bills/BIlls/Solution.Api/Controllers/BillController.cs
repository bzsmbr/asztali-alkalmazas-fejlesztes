using System.Threading.Tasks;

namespace Solution.Api.Controllers;

public class BillController(IBillService billService) : BaseController
{
    [HttpGet]
    [Route("api/bill/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await billService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/bill/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await billService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/bill/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        var result = await billService.DeleteAsync(id);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/item/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] BillModel model)
    {
        var result = await billService.CreateAsync(model);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/bill/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] BillModel model)
    {
        var result = await billService.UpdateAsync(model);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/bill/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute] int page = 0)
    {
        var result = await billService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
