namespace PortfolioWebApp.Services.Ideas;

public class IdeaAddService : IIdeaAddService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IdeaAddService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task AddToIdeas(InnovationIdeasModel model)
    {
        var _httpClient = _httpClientFactory.CreateClient("PortfolioApi");
        await _httpClient.PostAsJsonAsync($"IdeasAddIdea/AddIdea", model);
    }
}