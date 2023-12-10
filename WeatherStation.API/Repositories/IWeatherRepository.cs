using WeatherStation.API.Common.Models;

namespace WeatherStation.API.Repositories;

public interface IWeatherRepository
{
    Task<Weather> CreateWeatherAsync(Weather weather);
    Task<IEnumerable<Weather>> GetWeathersAsync();
}
