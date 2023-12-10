using WeatherStation.API.Common.Models;

namespace WeatherStation.API.Client.Clients;

public interface IWeatherClient
{
    Task<IList<Weather>> GetAllWeathers();
}
