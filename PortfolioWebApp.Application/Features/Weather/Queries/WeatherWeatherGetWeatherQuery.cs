
namespace PortfolioWebApp.Application.Features.Weather.Queries
{
    public class WeatherGetWeatherQuery: IRequest<WeatherHistoryModel>
    {
        public required string City { get; set; }
        public required string SCode { get; set; }
        public required string CCode { get; set; }
    }
}
