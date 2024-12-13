﻿namespace PortfolioWebApp.Domain.Interfaces.Ideas;

public interface IInnovationIdeasRepository
{
    Task<IEnumerable<InnovationIdeasEntity>> GetAllIdeas();

    Task<InnovationIdeasEntity> GetIdeaById(int ideaId);

    Task<InnovationIdeasEntity> AddToIdeas(InnovationIdeasEntity idea);

    Task DeleteIdea(int ideaId);

    Task ChangeStatus(int ideaId);

    Task RefreshLastUpdated(InnovationIdeasEntity idea);
}