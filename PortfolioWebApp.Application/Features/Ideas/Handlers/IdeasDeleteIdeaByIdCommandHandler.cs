namespace PortfolioWebApp.Application.Features.Ideas.Handlers
{
    public class IdeasDeleteIdeaByIdCommandHandler : IRequestHandler<IdeasDeleteIdeaByIdCommand, int>
    {
        private readonly IInnovationIdeasRepository _repository;
        private readonly IMapper _mapper;

        public IdeasDeleteIdeaByIdCommandHandler(IInnovationIdeasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(IdeasDeleteIdeaByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteIdea(request.ideaId);
            return 200;
        }
    }
}
