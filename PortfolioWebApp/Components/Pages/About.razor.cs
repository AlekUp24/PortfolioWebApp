using Microsoft.AspNetCore.HttpOverrides;
using System.Runtime.CompilerServices;
using PortfolioWebApp.Components.Widgets;

namespace PortfolioWebApp.Components.Pages
{
    public partial class About
    {
        public int StockPrice { get; set; } = 0;
        protected override async Task OnInitializedAsync()
        {
            // come up with stock prices
            await Task.Delay(1500);
            Random price = new Random();
            StockPrice = price.Next(100, 1000);
            
        }
    }
}
