using System.Threading.Tasks;
using WeatherModels;

namespace WeatherService
{
    public interface IDataService
    {
        Task<MyWeather> GetWeatherByCityAsync(string city);
    }
}