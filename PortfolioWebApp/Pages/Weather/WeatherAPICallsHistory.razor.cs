using Microsoft.AspNetCore.Components.QuickGrid;


namespace PortfolioWebApp.Components.Pages
{
    public partial class WeatherAPICallsHistory
    {
        //[Inject]
        //public IWeatherHistoryRepository? weatherHistoryRepository { get; set; }

        //protected IQueryable<WeatherHistory>? itemsWeatherHistory;
        //protected int historyCount;
        //public PaginationState pagination = new() { ItemsPerPage = 10 };

        //private string _searchQuery = string.Empty;
        //private string SearchQuery
        //{
        //    get => _searchQuery;
        //    set
        //    {
        //        _searchQuery = value;
        //        _ = SearchWeatherHistory();
        //    }
        //}

        //protected async override Task OnInitializedAsync()
        //{
        //    itemsWeatherHistory = (await weatherHistoryRepository.GetAllWeatherHistory())
        //        .OrderByDescending(x => x.DateTime).AsQueryable();
        //    historyCount = itemsWeatherHistory.Count();
        //}

        //private async Task SearchWeatherHistory()
        //{
        //    if (!string.IsNullOrEmpty(_searchQuery))
        //    {
        //        itemsWeatherHistory = (await weatherHistoryRepository.GetAllWeatherHistory())
        //            .OrderByDescending(x => x.DateTime)
        //            .Where(x => x.Country.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
        //                        x.City.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase)).AsQueryable();
        //    }
        //    else
        //    {
        //        itemsWeatherHistory = (await weatherHistoryRepository.GetAllWeatherHistory())
        //            .OrderByDescending(x => x.DateTime).AsQueryable();
        //    }

        //    historyCount = itemsWeatherHistory.Count();
        //    StateHasChanged(); 
        //}

        //private void resetQuery()
        //{
        //    SearchQuery = string.Empty;
        //}
    }
}

