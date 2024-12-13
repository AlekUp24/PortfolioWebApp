using System.Net.Http;

namespace PortfolioWebApp.Services.Ideas;

public class IdeaEditService : IIdeaEditService
{
    private readonly IMediator _mediator;
    private readonly IHttpClientFactory _httpClientFactory;

    public IdeaEditService(IMediator mediator, IHttpClientFactory httpClientFactory)
    {
        _mediator = mediator;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<InnovationIdeasModel> GetIdeaById(int IdeaId)
    {
        IdeasEditGetIdeaByIdQuery query = new IdeasEditGetIdeaByIdQuery() { IdeaId = IdeaId};
        return await _mediator.Send(query);
    }

    public async Task DeleteIdea(int IdeaId)
    {
        var _httpClient = _httpClientFactory.CreateClient("PortfolioApi");
        await _httpClient.GetAsync($"IdeasDelete/{IdeaId}");
    }

    public async Task RefreshLastUpdated(InnovationIdeasModel EditedIdea) 
    {
        IdeasRefreshLastUpdatedCommand query = new IdeasRefreshLastUpdatedCommand() { Idea = EditedIdea };
        await _mediator.Send(query);
    }
}