namespace PortfolioWebApp.Common.Models.Models
{
    public class WeatherHistoryModel
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string Description { get; set; }
        public decimal Temperature { get; set; }
        public decimal FeelsLike { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal Humidity { get; set; }
        public decimal Pressure { get; set; }
        public string IconUrl { get; set; }
    }
}
