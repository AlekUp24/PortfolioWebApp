namespace PortfolioWebApp.Application.Services.Weather
{
    public interface IWeatherService
    {
        Task<WeatherHistoryModel> GetCurrWeather(string City, string SCode, string CCode);
    }
}
