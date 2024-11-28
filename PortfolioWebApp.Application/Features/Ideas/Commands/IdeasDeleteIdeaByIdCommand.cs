namespace PortfolioWebApp.Application.Features.Ideas.Commands
{
    public class IdeasDeleteIdeaByIdCommand : IRequest<int>
    {
        public required int ideaId { get; set; }
    }
}
