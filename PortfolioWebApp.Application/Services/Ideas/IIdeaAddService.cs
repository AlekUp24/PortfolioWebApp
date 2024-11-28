namespace PortfolioWebApp.Application.Services.Ideas
{
    public interface IIdeaAddService
    {
        Task AddToIdeas(InnovationIdeasModel model);
    }
}
