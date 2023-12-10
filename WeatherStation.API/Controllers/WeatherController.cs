using Microsoft.AspNetCore.Mvc;
using WeatherStation.API.Common.Models;
using WeatherStation.API.Services;

namespace WeatherStation.API.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpPost]
        public async Task<ActionResult<Weather>> Create(Weather weather)
        {
            try
            {
                var result = await _weatherService.CreateWeatherAsync(weather);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var result = await _weatherService.GetWeathersAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
