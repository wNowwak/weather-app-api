namespace WeatherStation.API.Common.Models;

public class Weather
{
    public Guid Id { get; set; }
    public WeatherParameter? Pressure { get; set; }
    public WeatherParameter? Temperature { get; set; }
    public WeatherParameter? Humidity { get; set; }
    public DateTime Time { get; set; } = DateTime.UtcNow;
}
