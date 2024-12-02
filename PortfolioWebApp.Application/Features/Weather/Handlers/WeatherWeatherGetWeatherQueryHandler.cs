namespace PortfolioWebApp.Application.Features.Weather.Handlers;

public class WeatherWeatherGetWeatherQueryHandler: IRequestHandler<WeatherGetWeatherQuery, WeatherHistoryModel>
{
    private readonly IWeatherRepository _repository;
    private readonly IMapper _mapper;

    public WeatherWeatherGetWeatherQueryHandler(IWeatherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<WeatherHistoryModel> Handle(WeatherGetWeatherQuery request, CancellationToken cancellationToken) 
    {
        WeatherHistoryModel weather = new WeatherHistoryModel();
        var result = await _repository.GetLanLon(request.City, request.SCode, request.CCode);
        weather = _mapper.Map<WeatherHistoryEntity,WeatherHistoryModel>(result);
        return weather;
    }
}
