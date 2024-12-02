namespace PortfolioWebApp.Components;

public partial class SmallCalendar
{
                private string DisplayCalendar = string.Empty;
    private DateTime CurrentDateTime { get; set; }


    protected override void OnInitialized()
    {
        CurrentDateTime = DateTime.Now;
        DisplayCalendar = $"Today is {CurrentDateTime.ToString("dddd", new CultureInfo("en-US"))} " +
                            $"{CurrentDateTime.Day}{GetDaySuffix(CurrentDateTime.Day)} " +
                            $"of {CurrentDateTime.ToString("MMMM yyyy", new CultureInfo("en-US"))}";
    }

    private string GetDaySuffix(int day)
    {
        return day % 10 == 1 && day != 11 ? "st" :
               day % 10 == 2 && day != 12 ? "nd" :
               day % 10 == 3 && day != 13 ? "rd" : "th";
    }
}