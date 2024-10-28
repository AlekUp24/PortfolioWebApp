using PortfolioWebApp.Models;
using static PortfolioWebApp.Components.Pages.Weather;

namespace PortfolioWebApp.Contracts
{
    public interface IWeatherHistoryRepository
    {
        Task <IEnumerable<WeatherHistory>> GetAllWeatherHistory();
        Task<WeatherHistory> AddToWeatherHistory(WeatherHistory weatherHistory);
    }
}
