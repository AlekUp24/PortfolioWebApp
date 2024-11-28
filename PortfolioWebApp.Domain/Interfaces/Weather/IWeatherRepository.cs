namespace PortfolioWebApp.Domain.Interfaces.Weather
{
    public interface IWeatherRepository
    {
        Task <IEnumerable<WeatherHistoryEntity>> GetAllWeatherHistory();
        Task<WeatherHistoryEntity> AddToWeatherHistory(WeatherHistoryEntity weatherHistory);
        Task<WeatherHistoryEntity> GetLanLon(string City, string SCode, string CCode);
    }
}
