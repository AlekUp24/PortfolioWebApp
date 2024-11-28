namespace PortfolioWebApp.Application.Features.Ideas.Handlers
{
    public class IdeasEditGetIdeaByIdQueryHandler : IRequestHandler<IdeasEditGetIdeaByIdQuery, InnovationIdeasModel>
    {
        private readonly IInnovationIdeasRepository _repository;
        private readonly IMapper _mapper;

        public IdeasEditGetIdeaByIdQueryHandler(IInnovationIdeasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InnovationIdeasModel> Handle(IdeasEditGetIdeaByIdQuery request, CancellationToken cancellationToken)
        {
            InnovationIdeasModel idea = new InnovationIdeasModel();
            var result = await _repository.GetIdeaById(request.ideaId);
            idea = _mapper.Map<InnovationIdeasEntity,InnovationIdeasModel>(result);
            return idea;
        }
    }
}
