using Azure;
using PortfolioWebApp.Pages.Ideas;

namespace PortfolioWebApp.Services.Ideas;

public class IdeaEditService : IIdeaEditService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IdeaEditService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<InnovationIdeasModel> GetIdeaById(int IdeaId)
    {
        var _httpClient = _httpClientFactory.CreateClient("PortfolioApi");
        var response =  await _httpClient.GetFromJsonAsync<InnovationIdeasModel>($"IdeasGetIdeaByID/{IdeaId}");
        return response;
    }

    public async Task DeleteIdea(int IdeaId)
    {
        var _httpClient = _httpClientFactory.CreateClient("PortfolioApi");
        await _httpClient.DeleteAsync($"IdeasDelete/{IdeaId}");
    }

    public async Task RefreshLastUpdated(InnovationIdeasModel EditedIdea) 
    {
        var _httpClient = _httpClientFactory.CreateClient("PortfolioApi");
        await _httpClient.PatchAsync($"IdeasRefreshLastUpdated/RefreshLastUpdated", JsonContent.Create(EditedIdea));
    }
}