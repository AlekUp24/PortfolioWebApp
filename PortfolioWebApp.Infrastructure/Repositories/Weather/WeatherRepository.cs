using PortfolioWebApp.Infrastructure.Database;

namespace PortfolioWebApp.Infrastructure.Repositories.Weather
{
    public class WeatherRepository : IWeatherRepository, IDisposable
    {
        public readonly AppDbContext _appDbContext;
        public readonly HttpClient _httpClient;

        private string API_KEY = "";
        private WeatherData? response;
        private LocationData? location;
        private string iconUrl;
        private bool firstLoad;
        private bool locationFound;

        public WeatherRepository(IDbContextFactory<AppDbContext> DbFactory, HttpClient httpClient)
        {
            _appDbContext = DbFactory.CreateDbContext();
            _httpClient = httpClient;
            API_KEY = "a48e893f5b18eec63e166b52def1e3b0";
        }

        public class WeatherData
        {
            public MainData Main { get; set; }
            public WindData Wind { get; set; }
            public List<WeatherDescription> Weather { get; set; }
            public SysData Sys { get; set; }
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

        public class SysData
        {
            public string Country { get; set; }
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public async Task<IEnumerable<WeatherHistoryEntity>> GetAllWeatherHistory()
        {
            return await _appDbContext.WeatherHistory.ToListAsync();
        }

        public async Task<WeatherHistoryEntity> GetLanLon(string cityName, string stateCode, string countryCode)
        {
            firstLoad = false;
            locationFound = true;
            response = null;


                var locationDataList = await _httpClient.GetFromJsonAsync<List<LocationData>>($"http://api.openweathermap.org/geo/1.0/direct?q={cityName},{stateCode},{countryCode}&appid={API_KEY}");
                location = locationDataList?.FirstOrDefault();

                if (location != null)
                {
                        response = await _httpClient.GetFromJsonAsync<WeatherData>($"https://api.openweathermap.org/data/2.5/weather?lat={location.Lat}&lon={location.Lon}&appid={API_KEY}&units=metric");

                        if (response != null && response.Weather.Any())
                        {
                            iconUrl = "https://openweathermap.org/img/wn/" + response.Weather[0].Icon + "@2x.png";

                            WeatherHistoryEntity weatherHistory = new WeatherHistoryEntity() { 
                                DateTime = DateTime.Now, 
                                IconUrl = iconUrl,
                                Country = response.Sys.Country,
                                City = response.Name,
                                Lat = location.Lat,
                                Lon = location.Lon,
                                Description = response.Weather[0].Main,
                                Temperature = response.Main.Temp,
                                FeelsLike = response.Main.Feels_Like,
                                WindSpeed = response.Wind.Speed,
                                Humidity = Math.Round(response.Main.Humidity, 2),
                                Pressure = Math.Round(response.Main.Pressure, 2) };

                            await AddToWeatherHistory(weatherHistory);
                            return weatherHistory;
                        } 
                        else
                        {
                        response = null;
                        return null;
                        }
                }
                else
                {
                    locationFound = false;
                    return null;
                }
        }

        public async Task<WeatherHistoryEntity> AddToWeatherHistory(WeatherHistoryEntity weatherHistory)
        {
            // only check saved in last 5 minutes
            var existingRecord = await _appDbContext.WeatherHistory.FirstOrDefaultAsync(w =>
                               w.DateTime >= DateTime.Now.AddMinutes(-5)
                            && w.City == weatherHistory.City
                            && w.Lat == weatherHistory.Lat
                            && w.Lon == weatherHistory.Lon
                            && w.Description == weatherHistory.Description
                            && w.Temperature == weatherHistory.Temperature
                            && w.FeelsLike == weatherHistory.FeelsLike
                            && w.WindSpeed == weatherHistory.WindSpeed
                            && w.Humidity == weatherHistory.Humidity
                            && w.Pressure == weatherHistory.Pressure);

            if (existingRecord != null)
            {
                Console.WriteLine("Duplicate entry found, not adding to DB");
                return existingRecord;
            }
            var toBeAdded = await _appDbContext.WeatherHistory.AddAsync(weatherHistory);
            await _appDbContext.SaveChangesAsync();
            return toBeAdded.Entity;
        }
    }
}
