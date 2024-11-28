namespace PortfolioWebApp.Application.Features.Ideas.Commands
{
    public class IdeasAddIdeaFromFormCommand : IRequest<int>
    {
        public required InnovationIdeasModel model { get; set; }
    }
}
