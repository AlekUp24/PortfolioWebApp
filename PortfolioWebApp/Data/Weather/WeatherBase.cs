namespace PortfolioWebApp.Data.Weather;

public class WeatherBase : MainBase
{
    public bool FirstLoad;
    public bool LocationFound;
    public WeatherHistoryModel? Response;

    [SupplyParameterFromForm]
    public string CityName { get; set; }
    [SupplyParameterFromForm]
    public string StateCode { get; set; }
    [SupplyParameterFromForm]
    public string CountryCode { get; set; }


    protected async override Task OnInitializedAsync()
    {
        FirstLoad = true;
    }
    
    public async Task GetLanLon()
    {
        LocationFound = false;
        Response = null;
        FirstLoad = false;

        Response = await WeatherService.GetCurrWeather(CityName, StateCode, CountryCode);

        LocationFound = true;
    }
}