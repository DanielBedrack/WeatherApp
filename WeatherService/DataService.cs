using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using WeatherModels;

namespace WeatherService
{
    public class DataService : IDataService
    {
        readonly WebClient client = new WebClient();

        public MyWeather GetWeatherByCity(string city) =>
             JsonConvert.DeserializeObject<MyWeather>(
                 client.DownloadString($@"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=a0057f440991bfa0a5e22c2f64a3c1a9"));

        public Task<MyWeather> GetWeatherByCityAsync(string city) => Task.FromResult(GetWeatherByCity(city));

        #region The same
        //public MyWeather GetWeatherByCity(string city)
        //{
        //    string url = $@"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid=a0057f440991bfa0a5e22c2f64a3c1a9";
        //    string response = client.DownloadString(url);
        //    var weather = JsonConvert.DeserializeObject<MyWeather>(response);
        //    return weather;
        //}

        //public Task<MyWeather> GetWeatherByCityAsync(string city) => Task.Run(() => GetWeatherByCity(city));

        #endregion    
    }
}