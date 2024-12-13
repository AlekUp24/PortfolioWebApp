namespace PortfolioWebApp.Application.Features.Ideas.Handlers;

public class IdeasShowGetAllIdeasQueryHandler : IRequestHandler<IdeasShowGetAllIdeasQuery, IEnumerable<InnovationIdeasModel>>
{
    private readonly IInnovationIdeasRepository _repository;
    private readonly IMapper _mapper;

    public IdeasShowGetAllIdeasQueryHandler(IInnovationIdeasRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InnovationIdeasModel>> Handle(IdeasShowGetAllIdeasQuery request, CancellationToken cancellationToken)
    {
        List<InnovationIdeasModel> results = new List<InnovationIdeasModel>();
        var list = await _repository.GetAllIdeas();
        
        if (list == null)
        {
            return results;
        }
        foreach (InnovationIdeasEntity item in list)
        {
            results.Add(_mapper.Map<InnovationIdeasEntity, InnovationIdeasModel>(item));
        }
        return results;
    }
}
