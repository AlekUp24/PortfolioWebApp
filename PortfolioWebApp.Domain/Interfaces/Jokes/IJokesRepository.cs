namespace PortfolioWebApp.Domain.Interfaces.Jokes
{
    public interface IJokesRepository
    {
        Task<JokesResponseEntity> NextJokeAsync();
    }
}
