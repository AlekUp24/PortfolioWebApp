using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // add tables 
        public DbSet<WeatherHistory> WeatherHistory { get; set; }
    }
}
