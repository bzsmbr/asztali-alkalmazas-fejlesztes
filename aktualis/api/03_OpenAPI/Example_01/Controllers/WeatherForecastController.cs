namespace Example_01.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    /// <summary>
    /// Returns the weather forecasts
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetWeatherForecast")]
    [SwaggerOperation(Summary = "Returns the weather forecasts", Description = "Returns the weather forecasts.")]
    [ProducesResponseType(typeof(string[]), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> GetWeatherForecastsAsync()
    {
        var summaries = new string[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        return Ok(summaries);
    }
}
