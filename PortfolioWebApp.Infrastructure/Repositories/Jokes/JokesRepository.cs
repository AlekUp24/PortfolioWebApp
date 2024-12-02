namespace PortfolioWebApp.Infrastructure.Repositories.Jokes;

public class JokesRepository : IJokesRepository
{
    private readonly HttpClient _httpClient;

    public JokesRepository(HttpClient httpClient) 
    { 
        _httpClient = httpClient; 
    }
    
    public async Task<JokesResponseEntity> NextJokeAsync()
    {
        return await _httpClient.GetFromJsonAsync<JokesResponseEntity>("https://official-joke-api.appspot.com/jokes/random");
    }
}