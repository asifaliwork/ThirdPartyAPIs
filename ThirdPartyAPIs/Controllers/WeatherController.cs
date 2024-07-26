using Microsoft.AspNetCore.Mvc;
using ThirdPartyAPIs.Models;
using ThirdPartyAPIs.Services;

namespace ThirdPartyAPIs.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class WeatherController : Controller
    {
        private readonly IWeatherServices _weatherServices;

        public WeatherController(IWeatherServices weatherServices)
        {
            _weatherServices = weatherServices ?? throw new ArgumentNullException(nameof(weatherServices));
        }
        [HttpGet]
        public async Task<IActionResult> Index(string name)
        {
            var weather  = await _weatherServices.GetWeatherAsync(name);
            return Ok(weather);
        }
    }
}
