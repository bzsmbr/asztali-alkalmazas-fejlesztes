using Bills.Core.DTO.Requests;
using Bills.Core.Interfaces;
using Bills.Core.Models;
using Solution.Api.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Bills.Api.Controllers;

public class ItemController(IItemService itemService) : BaseController
{
    //ALL
    [HttpGet]
    [Route("api/items/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await itemService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //BY ID
    [HttpGet]
    [Route("api/items/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await itemService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //CREATE
    [HttpPost]
    [Route("api/items/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] ItemModelRequest item)
    {
        var result = await itemService.CreateAsync(item);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //UPDATE
    [HttpPut]
    [Route("api/items/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] ItemModelRequest item)
    {
        var result = await itemService.UpdateAsync(item);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //DELETE
    [HttpDelete]
    [Route("api/items/delete")]
    public async Task<IActionResult> DeleteAsync([FromBody][Required] ItemModelRequest item)
    {
        var result = await itemService.DeleteAsync(item);
        return result.Match(
            result => Accepted(),
            errors => Problem(errors)
        );
    }
}
