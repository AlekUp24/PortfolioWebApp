namespace PortfolioWebApp.Application.Features.Ideas.Commands;

public class IdeasChangeStatusCommand : IRequest<int>
{
    public required int IdeaId {  get; set; }
}
