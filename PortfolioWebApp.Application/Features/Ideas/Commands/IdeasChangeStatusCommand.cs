namespace PortfolioWebApp.Application.Features.Ideas.Commands;

public class IdeasChangeStatusCommand : IRequest<int>
{
    public required InnovationIdeasModel Idea {  get; set; }
}
