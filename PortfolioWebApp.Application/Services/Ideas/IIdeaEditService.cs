namespace PortfolioWebApp.Application.Services.Ideas;

public interface IIdeaEditService
{
    Task<InnovationIdeasModel> GetIdeaById(int IdeaId);
    Task DeleteIdea(int ideaId);
    Task RefreshLastUpdated(InnovationIdeasModel EditedIdea);
}