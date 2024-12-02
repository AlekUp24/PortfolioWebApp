using PortfolioWebApp.Data.Ideas;
using PortfolioWebApp.Domain.Entities.Ideas;

namespace PortfolioWebApp.Services.Ideas
{
    public class IdeasShowService: IIdeasShowService
    {
        private readonly IMediator _mediator;

        public IdeasShowService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ChangeStatus(InnovationIdeasModel idea)
        {
            IdeasChangeStatusCommand query = new IdeasChangeStatusCommand() { Idea = idea };
            await _mediator.Send(query);
        }

        public async Task<IEnumerable<InnovationIdeasModel>> GetAllIdeas()
        {
            IdeasShowGetAllIdeasQuery query = new IdeasShowGetAllIdeasQuery();
            return await _mediator.Send(query);
        }
    }
}
