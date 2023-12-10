using WeatherStation.API.Common.Models;
using WeatherStation.API.Repositories;

namespace WeatherStation.API.Services;

public class WeatherService : IWeatherService
{
    private readonly IWeatherRepository _repository;

    public WeatherService(IWeatherRepository repository)
    {
        _repository = repository;
    }

    public async Task<Weather> CreateWeatherAsync(Weather weather)
    {
        return await _repository.CreateWeatherAsync(weather);   
    }

    public async Task<IEnumerable<Weather>> GetWeathersAsync()
    {
        return await _repository.GetWeathersAsync();
    }
}
