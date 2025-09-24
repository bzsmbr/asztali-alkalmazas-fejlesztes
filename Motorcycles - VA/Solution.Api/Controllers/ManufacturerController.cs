namespace Solution.Api.Controllers;

public class ManufacturerController(IManufacturerService manufacturerService) : BaseController
{
    [HttpGet]
    [Route("api/manufacturer/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await manufacturerService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/manufacturer/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await manufacturerService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/manufacturer/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        var result = await manufacturerService.DeleteAsync(id);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/manufacturer/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] ManufacturerModel model)
    {
        var result = await manufacturerService.CreateAsync(model);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/manufacturer/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] ManufacturerModel model)
    {
        var result = await manufacturerService.UpdateAsync(model);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/manufacturer/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute] int page = 0)
    {
        var result = await manufacturerService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
