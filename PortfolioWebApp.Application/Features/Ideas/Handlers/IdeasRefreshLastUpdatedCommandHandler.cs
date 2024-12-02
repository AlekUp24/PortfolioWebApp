namespace PortfolioWebApp.Application.Features.Ideas.Handlers
{
    public class IdeasRefreshLastUpdatedCommandHandler : IRequestHandler<IdeasRefreshLastUpdatedCommand, int>
    {
        private readonly IInnovationIdeasRepository _repository;
        private readonly IMapper _mapper;

        public IdeasRefreshLastUpdatedCommandHandler(IInnovationIdeasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }   

        public async Task<int> Handle(IdeasRefreshLastUpdatedCommand request, CancellationToken cancellationToken)
        {
            var toRefresh = _mapper.Map<InnovationIdeasModel, InnovationIdeasEntity>(request.Idea);
            await _repository.RefreshLastUpdated(toRefresh);
            return 200;
        }
    }
}
