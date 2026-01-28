using System.ComponentModel;

namespace Solution.WebAPI.Controllers;

[ApiController]
[ProducesResponseType(statusCode: 400, type: typeof(BadRequestObjectResult))]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [Route("api/users")]
    [Authorize]
    [ProducesResponseType(type:typeof(ICollection<UserModel>), statusCode:200)]
    //[SwaggerOperation(Summary = "Get all users from the database.", Description = "Get all users from the database.")]
    [EndpointDescription("Get all users from the database.")]
    public async Task<IActionResult> GetUsersAsync()
    {
        var result = await userService.GetAllUsers();
        return result.Match(
            value => Ok(value),
            errors => errors.ToProblemResult()
        );
    }
}
