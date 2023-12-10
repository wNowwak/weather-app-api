using System.Net.Http;
using System.Net.Http.Json;
using WeatherStation.API.Common.Models;

namespace WeatherStation.API.Client.Clients;

public class WeatherClient : IWeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient(nameof(WeatherClient));
    }

    public async Task<IList<Weather>> GetAllWeathers()
    {
        var url = "api/weather";
        var result = await _httpClient.GetFromJsonAsync<IList<Weather>>(url);
        return result!;
    }
}
