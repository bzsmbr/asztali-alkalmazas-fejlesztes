using Bills.Core.Interfaces;
using Bills.Core.Models;
using ErrorOr;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace Bills.Api.Controllers;

public class BillController(IBillService billService) :BaseController
{
    //ALL
    [HttpGet]
    [Route("api/bills")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await billService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //BY ID
    [HttpGet]
    [Route("api/bills/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await billService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //PAGED
    [HttpGet]
    [Route("api/bills/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute] int page = 0)
    {
        var result = await billService.GetPagedAsync(page);

        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //CREATE
    [HttpPost]
    [Route("api/bills/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] BillModel bill)
    {
        var result = await billService.CreateAsync(bill);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //UPDATE
    [HttpPut]
    [Route("api/bills/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] BillModel bill)
    {
        var result = await billService.UpdateAsync(bill);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    //DELETE
    [HttpDelete]
    [Route("api/bills/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute][Required] int id)
    {
        var result = await billService.DeleteAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
