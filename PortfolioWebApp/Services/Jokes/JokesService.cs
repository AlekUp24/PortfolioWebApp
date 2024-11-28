namespace PortfolioWebApp.Services.Jokes
{
    public class JokesService: IJokesService
    {
        private readonly IMediator _mediator;

        public JokesService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<JokesResponseModel> NextJokeAsync()
        {
            JokesGetNextJokeQuery query = new JokesGetNextJokeQuery();
            return await _mediator.Send(query);
        }
    }
}
