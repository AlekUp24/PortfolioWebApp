namespace PortfolioWebApp.Application.Services.Ideas;

public interface IIdeasShowService
{
    Task<IEnumerable<InnovationIdeasModel>> GetAllIdeas();
    Task ChangeStatus(int ideaId);
}