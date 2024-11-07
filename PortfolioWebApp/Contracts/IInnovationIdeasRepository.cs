using PortfolioWebApp.Models;

namespace PortfolioWebApp.Contracts
{
    public interface IInnovationIdeasRepository
    {
        Task<IEnumerable<InnovationIdeas>> GetAllIdeas();

        Task<InnovationIdeas> AddToIdeas(InnovationIdeas idea);

        Task ChangeStatus(InnovationIdeas idea);
    }
}
