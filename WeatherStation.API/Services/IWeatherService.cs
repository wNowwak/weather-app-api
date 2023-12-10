using WeatherStation.API.Common.Models;

namespace WeatherStation.API.Services;

public interface IWeatherService
{
    Task<Weather> CreateWeatherAsync(Weather weather); 
    Task<IEnumerable<Weather>> GetWeathersAsync(); 
}
