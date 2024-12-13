using PortfolioWebApp.Pages.Ideas;
using System.Text;

namespace PortfolioWebApp.Services.Ideas;

public class IdeasShowService : IIdeasShowService
{
    private readonly IMediator _mediator;
    private readonly IHttpClientFactory _httpClientFactory;

    public IdeasShowService(IMediator mediator, IHttpClientFactory httpClientFactory)
    {
        _mediator = mediator;
        _httpClientFactory = httpClientFactory;
    }

    public async Task ChangeStatus(int ideaId)
    {
        try
        {
            var _httpClient = _httpClientFactory.CreateClient("PortfolioApi");
            var content = new StringContent("", Encoding.UTF8, "application/json");
            await _httpClient.PatchAsync($"IdeasChangeStatus/{ideaId}", content);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "- Change Status");
        }
    }

    public async Task<IEnumerable<InnovationIdeasModel>> GetAllIdeas()
    {
        try
        {
            var _httpClient = _httpClientFactory.CreateClient("PortfolioApi");
            IEnumerable<InnovationIdeasModel> result = await _httpClient.GetFromJsonAsync<IEnumerable<InnovationIdeasModel>>("IdeasGetAll");
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + "xx");
            return null;
        }
    }
}