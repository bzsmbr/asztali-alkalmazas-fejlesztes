namespace Solution.Api.Controllers;

public class MotorcycleController(IMotorcycleService motorcycleService) : BaseController
{
    //get all
    [HttpGet]
    [Route("api/motorcycles/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await motorcycleService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //get by id
    [HttpGet]
    [Route("api/motorcycles/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] string id)
    {
        var result = await motorcycleService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //create
    [HttpPost]
    [Route("api/motorcycles/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] MotorcycleModel model)
    {
        var result = await motorcycleService.CreateAsync(model);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //update
    [HttpPut]
    [Route("api/motorcycles/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] MotorcycleModel model)
    {
        var result = await motorcycleService.UpdateAsync(model);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );

    }

    //delete
    [HttpDelete]
    [Route("api/motorcycles/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute][Required] string id)
    {
        var result = await motorcycleService.DeleteAsync(id);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }
}