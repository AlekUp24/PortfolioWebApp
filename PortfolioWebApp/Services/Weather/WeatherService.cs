namespace PortfolioWebApp.Services.Weather;

public class WeatherService : IWeatherService
{
    private readonly IMediator _mediator;

    public WeatherService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<WeatherHistoryModel> GetCurrWeather(string City, string SCode, string CCode)
    {
        WeatherGetWeatherQuery query = new WeatherGetWeatherQuery() { City = City, SCode = SCode, CCode = CCode };
        return await _mediator.Send(query);
    }

    public async Task<IQueryable<WeatherHistoryModel>> GetAllWeatherHistory() 
    {
        WeatherGetAllWeatherHistoryQuery query = new WeatherGetAllWeatherHistoryQuery();
        return await _mediator.Send(query);
    }
}