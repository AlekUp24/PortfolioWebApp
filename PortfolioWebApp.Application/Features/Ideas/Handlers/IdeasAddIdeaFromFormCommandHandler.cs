namespace PortfolioWebApp.Application.Features.Ideas.Handlers;

public class IdeasAddIdeaFromFormCommandHandler : IRequestHandler<IdeasAddIdeaFromFormCommand, int>
{
    private readonly IInnovationIdeasRepository _repository;
    private readonly IMapper _mapper;

    public IdeasAddIdeaFromFormCommandHandler(IInnovationIdeasRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }   

    public async Task<int> Handle(IdeasAddIdeaFromFormCommand request, CancellationToken cancellationToken)
    {
        var command =  _mapper.Map<InnovationIdeasModel,InnovationIdeasEntity> (request.Model);
        await _repository.AddToIdeas(command);
        return 200;
   }
}
