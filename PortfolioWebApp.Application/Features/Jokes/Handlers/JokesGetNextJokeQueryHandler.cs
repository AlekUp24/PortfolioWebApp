namespace PortfolioWebApp.Application.Features.Jokes.Handlers;

public class JokesGetNextJokeQueryHandler : IRequestHandler<JokesGetNextJokeQuery, JokesResponseModel>
{
    private readonly IJokesRepository _jokesRepository;
    private readonly IMapper _mapper;

    public JokesGetNextJokeQueryHandler(IJokesRepository jokesRepository, IMapper mapper)
    {
        _jokesRepository = jokesRepository;
        _mapper = mapper;
    }

    public async Task<JokesResponseModel> Handle(JokesGetNextJokeQuery request, CancellationToken cancellationToken)
    {
        JokesResponseModel response = new JokesResponseModel();
        var result = await _jokesRepository.NextJokeAsync();
        response = _mapper.Map<JokesResponseEntity, JokesResponseModel>(result);
        return response;
    }
}
