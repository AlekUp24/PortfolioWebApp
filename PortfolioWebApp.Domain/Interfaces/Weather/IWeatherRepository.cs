namespace PortfolioWebApp.Domain.Interfaces.Weather
{
    public interface IWeatherRepository
    {
        Task <IEnumerable<WeatherHistoryEntity>> GetAllWeatherHistory();
        Task<WeatherHistoryEntity> AddToWeatherHistory(WeatherHistoryEntity weatherHistory);
    }
}
