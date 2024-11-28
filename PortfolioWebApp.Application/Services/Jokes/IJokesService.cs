namespace PortfolioWebApp.Application.Services.Jokes
{
    public interface IJokesService
    {
        Task<JokesResponseModel> NextJokeAsync();
    }
}
