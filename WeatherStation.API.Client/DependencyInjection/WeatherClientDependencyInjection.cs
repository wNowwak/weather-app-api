using Microsoft.Extensions.DependencyInjection;
using WeatherStation.API.Client.Clients;

namespace WeatherStation.API.Client.DependencyInjection;

public static class WeatherClientDependencyInjection
{
    public static void AddWeatherClient(this IServiceCollection collection)
    {
        collection.AddHttpClient(nameof(WeatherClient), opt =>
        {
            opt.BaseAddress = new Uri("http://192.168.1.44:8082");
        });
        collection.AddSingleton<IWeatherClient, WeatherClient>();
    }
}
