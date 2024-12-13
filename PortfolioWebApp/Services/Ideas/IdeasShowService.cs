namespace PortfolioWebApp.Services.Ideas;

public class IdeasShowService : IIdeasShowService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public IdeasShowService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task ChangeStatus(int ideaId)
    {
        var _httpClient = _httpClientFactory.CreateClient("PortfolioApi");
        var content = new StringContent("", Encoding.UTF8, "application/json");
        await _httpClient.PatchAsync($"IdeasChangeStatus/{ideaId}", content);
    }

    public async Task<IEnumerable<InnovationIdeasModel>> GetAllIdeas()
    {
        var _httpClient = _httpClientFactory.CreateClient("PortfolioApi");
        IEnumerable<InnovationIdeasModel> ?result = await _httpClient.GetFromJsonAsync<IEnumerable<InnovationIdeasModel>>("IdeasGetAll");
        return result;
    }
}