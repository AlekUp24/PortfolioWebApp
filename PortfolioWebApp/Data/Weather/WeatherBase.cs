namespace PortfolioWebApp.Data.Weather;

public class WeatherBase : MainBase
{
    public bool firstLoad;
    public bool locationFound;
    public WeatherHistoryModel? response;

    [SupplyParameterFromForm]
    public string cityName { get; set; }
    [SupplyParameterFromForm]
    public string stateCode { get; set; }
    [SupplyParameterFromForm]
    public string countryCode { get; set; }


    protected async override Task OnInitializedAsync()
    {
        firstLoad = true;
    }
    
    public async Task GetLanLon()
    {
        locationFound = false;
        response = null;
        firstLoad = false;

        response = await WeatherService.GetCurrWeather(cityName, stateCode, countryCode);

        locationFound = true;
    }
}