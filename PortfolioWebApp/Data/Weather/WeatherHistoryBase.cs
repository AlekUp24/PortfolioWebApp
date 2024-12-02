namespace PortfolioWebApp.Data.Weather;

public class WeatherHistoryBase : MainBase
{

    protected IQueryable<WeatherHistoryModel>? ItemsWeatherHistory;
    protected int HistoryCount;
    public PaginationState Pagination = new() { ItemsPerPage = 10 };

    private string _searchQuery = string.Empty;
    
    private string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            _ = SearchWeatherHistory();
        }
    }

    protected async override Task OnInitializedAsync()
    {
        ItemsWeatherHistory = (await WeatherService.GetAllWeatherHistory())
            .OrderByDescending(x => x.DateTime).AsQueryable();
        HistoryCount = ItemsWeatherHistory.Count();
    }

    private async Task SearchWeatherHistory()
    {
        if (!string.IsNullOrEmpty(_searchQuery))
        {
            ItemsWeatherHistory = (await WeatherService.GetAllWeatherHistory())
                .OrderByDescending(x => x.DateTime)
                .Where(x => x.Country.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
                            x.City.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase)).AsQueryable();
        }
        else
        {
            ItemsWeatherHistory = (await WeatherService.GetAllWeatherHistory())
                .OrderByDescending(x => x.DateTime).AsQueryable();
        }

        HistoryCount = ItemsWeatherHistory.Count();
        StateHasChanged();
    }

    private void resetQuery()
    {
        SearchQuery = string.Empty;
    }
}