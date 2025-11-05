namespace Solution.Api.Controllers;

public class TypeController(ITypeService typeService) : BaseController
{
    [HttpGet]
    [Route("api/type/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await typeService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/type/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await typeService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/type/delete/id/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        var result = await typeService.DeleteAsync(id);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/type/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] TypeModel model)
    {
        var result = await typeService.CreateAsync(model);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/type/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] TypeModel model)
    {
        var result = await typeService.UpdateAsync(model);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/type/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute] int page = 0)
    {
        var result = await typeService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}