using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using WeatherModels;
using WeatherService;

namespace WpfWeather.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService service;
        public RelayCommand GetWeatherCommand { get; set; }
        public string CityName { get; set; }

        private MyWeather weather;
        public MyWeather Weather { get => weather; set => Set(ref weather, value); }

        public MainViewModel(IDataService service)
        {
            this.service = service;
            GetWeatherCommand = new RelayCommand(GetWeather);
        }

        private async void GetWeather() => Weather = await service.GetWeatherByCityAsync(CityName);
    }
}