namespace PortfolioWebApp.Data.Jokes;

public class JokesBase : MainBase
{
    public JokesResponseModel? response;
    public string hiddenPunchline = "* hidden *";
    public bool isInitialized = false;
    public string btnAttribute = "btn btn-success";


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        response = await JokesService.NextJokeAsync();
    }

    public async Task NextJokeAsync()
    {
        response = null;
        response = await JokesService.NextJokeAsync();
        hiddenPunchline = "* hidden *";
        btnAttribute = "btn btn-success";
    }

    public void GetPunchline()
    {
        hiddenPunchline = response.Punchline;
        btnAttribute = "btn btn-secondary disabled";
    }

}