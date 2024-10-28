using Microsoft.AspNetCore.Components.QuickGrid;
using Microsoft.AspNetCore.Components;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Components.Pages
{
    public partial class WeatherAPICallsHistory
    {
        [Inject]
        public IWeatherHistoryRepository? weatherHistoryRepository { get; set; }

        protected IQueryable<WeatherHistory>? itemsWeatherHistory;
        protected int historyCount;
        public PaginationState pagination = new() { ItemsPerPage = 10 };

        protected async override Task OnInitializedAsync()
        {
            itemsWeatherHistory = (await weatherHistoryRepository.GetAllWeatherHistory()).AsQueryable();
            historyCount = itemsWeatherHistory.Count();
        }
    }
}

