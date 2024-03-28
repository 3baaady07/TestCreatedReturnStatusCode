using Microsoft.AspNetCore.Mvc;

namespace TestCreatedReturnStatusCode.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost("/test")]
    public IActionResult Test()
    {
        /// the docs, here, state that the following function invokation 
        /// returns a status code of <see cref="StatusCodes.Status201Created"/>
        /// where as in reality it returns a <see cref="StatusCodes.Status204NoContent"/>
        return Created();
    }
}