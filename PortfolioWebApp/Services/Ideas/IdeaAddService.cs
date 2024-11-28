namespace PortfolioWebApp.Services.Ideas
{
    public class IdeaAddService : IIdeaAddService
    {
        private readonly IMediator _mediator;

        public IdeaAddService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task AddToIdeas(InnovationIdeasModel model) 
        {
            IdeasAddIdeaFromFormCommand command = new IdeasAddIdeaFromFormCommand() { model = model};

            await _mediator.Send(command);
        }
    }
}
