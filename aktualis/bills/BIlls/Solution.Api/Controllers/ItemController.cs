

namespace Solution.Api.Controllers;

public class ItemController(IItemService itemService) : BaseController
{
    [HttpGet]
    [Route("api/item/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await itemService.GetAllAsync();

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/item/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await itemService.GetByIdAsync(id);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/item/delete/id/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        var result = await itemService.DeleteAsync(id);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/item/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] ItemModel model)
    {
        var result = await itemService.CreateAsync(model);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/item/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] ItemModel model)
    {
        var  result = await itemService.UpdateAsync(model);

        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/item/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute] int page = 0)
    {
        var result = await itemService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}