namespace Solution.Api.Controllers;

public class MotorcycleController(IMotorcycleService motorcycleService): BaseController
{
    [HttpGet]
    [Route("api/motorcycle/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await motorcycleService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/motorcycle/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] [Required] string id)
    {
        var result = await motorcycleService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/motorcycle/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] string id)
    {
        var result = await motorcycleService.DeleteAsync(id);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/motorcycle/create")]
    public async Task<IActionResult> CreateAsync([FromBody] [Required] MotorcycleModel model)
    {
        var result = await motorcycleService.CreateAsync(model);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/motorcycle/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] MotorcycleModel model)
    {
        var result = await motorcycleService.UpdateAsync(model);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/motorcycle/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute] int page = 0)
    {
        var result = await motorcycleService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}