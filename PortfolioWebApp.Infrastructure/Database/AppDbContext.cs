namespace PortfolioWebApp.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // add tables 
    public DbSet<WeatherHistoryEntity> WeatherHistory { get; set; }
    public DbSet<InnovationIdeasEntity> InnovationIdeas { get; set; }
}