namespace PortfolioWebApp.Services.Ideas
{
    public class IdeaEditService : IIdeaEditService
    {
        private readonly IMediator _mediator;

        public IdeaEditService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<InnovationIdeasModel> GetIdeaById(int IdeaId)
        {
            IdeasEditGetIdeaByIdQuery query = new IdeasEditGetIdeaByIdQuery() { IdeaId = IdeaId};
            return await _mediator.Send(query);
        }

        public async Task DeleteIdea(int IdeaId)
        {
            IdeasDeleteIdeaByIdCommand query = new IdeasDeleteIdeaByIdCommand() { IdeaId = IdeaId };
            await _mediator.Send(query);
        }

        public async Task RefreshLastUpdated(InnovationIdeasModel EditedIdea) 
        {
            IdeasRefreshLastUpdatedCommand query = new IdeasRefreshLastUpdatedCommand() { Idea = EditedIdea };
            await _mediator.Send(query);
        }
    }
}
