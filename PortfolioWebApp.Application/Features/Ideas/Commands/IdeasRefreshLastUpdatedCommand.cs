namespace PortfolioWebApp.Application.Features.Ideas.Commands
{
    public class IdeasRefreshLastUpdatedCommand : IRequest<int>
    {
        public required InnovationIdeasModel Idea { get; set; }
    }
}
