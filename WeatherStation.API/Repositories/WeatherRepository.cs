using LiteDB;
using WeatherStation.API.Common.Models;
using WeatherStation.API.Models;

namespace WeatherStation.API.Repositories;
public class WeatherRepository : IWeatherRepository
{
    private readonly DbConfiguration _dbConfiguration;
    private string _databaseDirectory = string.Empty;
    private readonly string _databasePath;
    public WeatherRepository(IConfiguration configuration)
    {
        _dbConfiguration = new DbConfiguration();
        configuration.GetSection(nameof(DbConfiguration)).Bind(_dbConfiguration);
        CreateDatabaseDirectoryIfNeeded();
        _databasePath = Path.Combine(_databaseDirectory, _dbConfiguration.DatabaseName);
    }
    public Task<Weather> CreateWeatherAsync(Weather weather)
    {
        using (var db = new LiteDatabase(_databasePath))
        {
            var collection = db.GetCollection<Weather>(_dbConfiguration.WeatherCollectionName);

            collection.Insert(weather);
        }

        return Task.FromResult(weather);
    }

    public Task<IEnumerable<Weather>> GetWeathersAsync()
    {
        IEnumerable<Weather> result = new List<Weather>();
        using (var db = new LiteDatabase(_databasePath))
        {
            var collection = db.GetCollection<Weather>(_dbConfiguration.WeatherCollectionName);

            result = collection.Query().OrderByDescending(_ => _.Time).ToList();
        }
        return Task.FromResult(result);

    }

    private void CreateDatabaseDirectoryIfNeeded()
    {
        string appDataPath = string.Empty;
        try
        {
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        catch (Exception)
        {
            appDataPath = string.Empty;
        }
        _databaseDirectory = Path.Combine(appDataPath, "WeatherApp");
        if(!Directory.Exists(_databaseDirectory))
        {
            Directory.CreateDirectory(_databaseDirectory);
        }
    }
}
