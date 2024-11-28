namespace PortfolioWebApp.Data._Base
{
    public class MainBase : ComponentBase
    {
        [Inject]
        public HttpClient http {  get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJokesService JokesService { get; set; } = default!;

        [Inject]
        public IIdeaAddService IdeaAddService { get; set; } = default!;

        [Inject]
        public IIdeaEditService IdeaEditService { get; set; } = default!;

        [Inject]
        public IIdeasShowService IdeasShowService { get; set; } = default!;

        //[Inject]
        //public IWeatherService WeatherService { get; set; } = default!;

        [Inject]
        public IConfiguration _config { get; set; } = default!;
    }
}
