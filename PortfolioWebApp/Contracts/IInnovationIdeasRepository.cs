using PortfolioWebApp.Models;

namespace PortfolioWebApp.Contracts
{
    public interface IInnovationIdeasRepository
    {
        Task<IEnumerable<InnovationIdeas>> GetAllIdeas();

        Task<InnovationIdeas> GetIdeaById(int ideaId);

        Task<InnovationIdeas> AddToIdeas(InnovationIdeas idea);

        Task DeleteIdea(int ideaId);

        Task ChangeStatus(InnovationIdeas idea);
    }
}
