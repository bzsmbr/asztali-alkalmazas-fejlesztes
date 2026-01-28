using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace Solution.WebAPI.Controllers;

[ApiController]
[ProducesResponseType(statusCode: 400, type:typeof(BadRequestObjectResult))]
public class SecurityController(ISecurityService securityService) : ControllerBase
{
    [HttpPost]
    [Route("api/security/register")]
    [ProducesResponseType(type:typeof(Success), statusCode:200)]
    //[SwaggerOperation( Summary = "Register a user using email and passwords.", Description = "Register a user using email and passwords.")]
    [EndpointDescription("Register a user using email and passwords.")]
    public async Task<IActionResult> Register([FromBody] [Required] RegisterRequestModel model)
    {
        var result = await securityService.RegisterAsync(model);
        return result.Match(
            value => Ok(value),
            errors => errors.ToProblemResult()
        );
    }

    [HttpPost]
    [Route("api/security/login")]
    [ProducesResponseType(type: typeof(Success), statusCode: 200)]
    //[SwaggerOperation(Summary = "Login a user using email and passwords.", Description = "Login a user using email and passwords.")]
    [EndpointDescription("Login a user using email and passwords.")]
    public async Task<IActionResult> Login([FromBody] [Required] LoginRequestModel model)
    {
        var result = await securityService.LoginAsync(model);
        return result.Match(
            value => Ok(value),
            errors => errors.ToProblemResult()
        );
    }
}
