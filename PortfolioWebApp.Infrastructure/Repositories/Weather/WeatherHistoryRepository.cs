namespace PortfolioWebApp.Infrastructure.Repositories.Weather
{
    public class WeatherRepository : IWeatherRepository, IDisposable
    {
        public readonly AppDbContext _appDbContext;

        public WeatherRepository(IDbContextFactory<AppDbContext> DbFactory)
        {
            _appDbContext = DbFactory.CreateDbContext();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public async Task<IEnumerable<WeatherHistoryEntity>> GetAllWeatherHistory()
        {
            return await _appDbContext.WeatherHistory.ToListAsync();
        }

        public async Task<WeatherHistoryEntity> AddToWeatherHistory(WeatherHistoryEntity weatherHistory)
        {
            // only check saved in last 5 minutes
            var existingRecord = await _appDbContext.WeatherHistory.FirstOrDefaultAsync(w =>
                               w.DateTime >= DateTime.Now.AddMinutes(-5)
                            && w.City == weatherHistory.City
                            && w.Lat == weatherHistory.Lat
                            && w.Lon == weatherHistory.Lon
                            && w.Description == weatherHistory.Description
                            && w.Temperature == weatherHistory.Temperature
                            && w.FeelsLike == weatherHistory.FeelsLike
                            && w.WindSpeed == weatherHistory.WindSpeed
                            && w.Humidity == weatherHistory.Humidity
                            && w.Pressure == weatherHistory.Pressure);

            if (existingRecord != null)
            {
                Console.WriteLine("Duplicate entry found, not adding to DB");
                return existingRecord;
            }
            var toBeAdded = await _appDbContext.WeatherHistory.AddAsync(weatherHistory);
            await _appDbContext.SaveChangesAsync();
            Console.WriteLine("Added to DB");
            return toBeAdded.Entity;
        }
    }
}
