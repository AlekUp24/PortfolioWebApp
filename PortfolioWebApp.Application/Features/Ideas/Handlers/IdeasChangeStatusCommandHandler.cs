namespace PortfolioWebApp.Application.Features.Ideas.Handlers;

public class IdeasChangeStatusCommandHandler : IRequestHandler<IdeasChangeStatusCommand, int>
{
    private readonly IInnovationIdeasRepository _repository;
    private readonly IMapper _mapper;

    public IdeasChangeStatusCommandHandler(IInnovationIdeasRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> Handle(IdeasChangeStatusCommand request, CancellationToken cancellationToken)
    {
        await _repository.ChangeStatus(request.IdeaId);
        return 200;
    }
}

