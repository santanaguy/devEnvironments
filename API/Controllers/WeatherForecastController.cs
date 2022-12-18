using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Flurl.Http;
using Flurl;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly APIConfig config;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<APIConfig> config)
        {
            _logger = logger;
            this.config = config.Value;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            return Ok(await (await this.config.Url.AppendPathSegment("weatherForecast").GetAsync()).GetJsonAsync<List<WeatherForecast>>());
        }
    }
}