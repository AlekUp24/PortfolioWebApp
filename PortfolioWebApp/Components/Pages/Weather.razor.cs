using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;
using static PortfolioWebApp.Components.Widgets.Jokes;

namespace PortfolioWebApp.Components.Pages

{
    public partial class Weather
    {
        private WeatherData? response;
        private LocationData? location;
        private string iconUrl;
        private bool firstLoad;
        private bool locationFound;

        // to HIDE later
        private string API_KEY = "a48e893f5b18eec63e166b52def1e3b0";


        [SupplyParameterFromForm]
        protected string cityName { get;   set; }
        [SupplyParameterFromForm]
        protected string stateCode { get; set; }
        [SupplyParameterFromForm]
        protected string countryCode { get; set; }



        protected async override Task OnInitializedAsync()
        {
            firstLoad = true;
        }

        public class WeatherData
        {
            public MainData Main { get; set; }
            public WindData Wind { get; set; }
            public List<WeatherDescription> Weather { get; set; }
            public string Name { get; set; } = string.Empty;

        }

        public class MainData
        {
            public decimal Temp { get; set; }
            public decimal Feels_Like { get; set; }
            public decimal Humidity { get; set; }
            public decimal Pressure { get; set; }

        }

        public class WindData
        {
            public decimal Speed { get; set; }
        }

        public class WeatherDescription
        {
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }

        public class LocationData
        {
            public decimal Lat { get; set; }
            public decimal Lon { get; set; }
        }

        public async Task GetCurrWeather(decimal lat, decimal lon)
        {
            try
            {
                response = await Http.GetFromJsonAsync<WeatherData>($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={API_KEY}&units=metric");

                if (response != null && response.Weather.Any())
                {
                    iconUrl = "https://openweathermap.org/img/wn/" + response.Weather[0].Icon + "@2x.png";
                }
            }
            catch (Exception ex)
            {
                response = null;
            }
        }

        public async Task GetLanLon()
        {
            firstLoad = false; 
            locationFound = true;
            response = null;

            try
            {
                var locationDataList = await Http.GetFromJsonAsync<List<LocationData>>($"http://api.openweathermap.org/geo/1.0/direct?q={cityName},{stateCode},{countryCode}&appid={API_KEY}");
                location = locationDataList?.FirstOrDefault();

                if (location != null)
                {
                    await GetCurrWeather(location.Lat, location.Lon);
                }
                else
                {
                    locationFound = false;
                }
            }
            catch (Exception ex)
            {
                locationFound = false;
            }
        }
    }
}

