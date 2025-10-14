using System.Threading.Tasks;

namespace Solution.Api.Controllers;

public class PhoneController(IPhoneService phoneService): BaseController
{
    [HttpGet]
    [Route("api/phone/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await phoneService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/phone/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] [Required] string id)
    {
        var result = await phoneService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/phone/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] string id)
    {
        var result = await phoneService.DeleteAsync(id);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/phone/create")]
    public async Task<IActionResult> CreateAsync([FromBody] [Required] PhoneModel model)
    {
        var result = await phoneService.CreateAsync(model);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/phone/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] PhoneModel model)
    {
        var result = await phoneService.UpdateAsync(model);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/phone/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute] int page = 0)
    {
        var result = await phoneService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}