namespace PortfolioWebApp.Application.Features.Weather.Handlers;

public class WeatherGetAllWeatherHistoryQueryHandler : IRequestHandler<WeatherGetAllWeatherHistoryQuery, IQueryable<WeatherHistoryModel>>
{
    private readonly IWeatherRepository _repository;
    private readonly IMapper _mapper;

    public WeatherGetAllWeatherHistoryQueryHandler(IWeatherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IQueryable<WeatherHistoryModel>> Handle(WeatherGetAllWeatherHistoryQuery request, CancellationToken cancellationToken)
    {
        List<WeatherHistoryModel> results = new List<WeatherHistoryModel>();
        var list = await _repository.GetAllWeatherHistory();

        if (list == null)
        {
            return results.AsQueryable();
        }
        foreach (WeatherHistoryEntity item in list)
        {
            results.Add(_mapper.Map<WeatherHistoryEntity, WeatherHistoryModel>(item));
        }

        return results.AsQueryable();
    }
}
