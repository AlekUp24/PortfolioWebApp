namespace PortfolioWebApp.Data.Jokes;

public class JokesBase : MainBase
{
    public JokesResponseModel? Response;
    public string HiddenPunchline = "* hidden *";
    public bool IsInitialized = false;
    public string BtnAttribute = "btn btn-success";


    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Response = await JokesService.NextJokeAsync();
    }

    public async Task NextJokeAsync()
    {
        Response = null;
        Response = await JokesService.NextJokeAsync();
        HiddenPunchline = "* hidden *";
        BtnAttribute = "btn btn-success";
    }

    public void GetPunchline()
    {
        HiddenPunchline = Response.Punchline;
        BtnAttribute = "btn btn-secondary disabled";
    }

}