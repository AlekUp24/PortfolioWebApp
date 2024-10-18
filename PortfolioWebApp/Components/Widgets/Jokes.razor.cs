namespace PortfolioWebApp.Components.Widgets
{
    public partial class Jokes
    {
        private JokesResponse? response;
        private string hiddenPunchline = string.Empty;
        private bool isInitialized = false;

        protected override async Task OnInitializedAsync()
        {
            await NextJokeAsync();
        }

        public async Task NextJokeAsync()
        {
            response = null;
            hiddenPunchline = "* hidding response *";
            // use Http from DI
            response = await Http.GetFromJsonAsync<JokesResponse>("https://official-joke-api.appspot.com/jokes/random");
        }

        public class JokesResponse
        {
            public string? Setup { get; set; }
            public string? Punchline { get; set; }
        }

        public void GetPunchline()
        {
            hiddenPunchline = response.Punchline;
        }

    }
}
