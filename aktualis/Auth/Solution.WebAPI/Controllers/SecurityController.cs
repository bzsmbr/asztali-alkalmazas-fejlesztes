namespace Solution.WebAPI.Controllers;

[ApiController]
public class SecurityController(ISecurityService securityService) : ControllerBase
{
    [HttpPost]
    [Route("api/security/register")]
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
    public async Task<IActionResult> Login([FromBody] [Required] LoginRequestModel model)
    {
        var result = await securityService.LoginAsync(model);
        return result.Match(
            value => Ok(value),
            errors => errors.ToProblemResult()
        );
    }
}
