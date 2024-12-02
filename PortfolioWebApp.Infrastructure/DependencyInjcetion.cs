namespace PortfolioWebApp.Infrastructure;

public static class DependencyInjcetion
{
    public static void AddInfrustructure(this IServiceCollection services)
    {
        services.AddScoped<IWeatherRepository, WeatherRepository>();
        services.AddScoped<IInnovationIdeasRepository, InnovationIdeasRepository>();
        services.AddScoped<IJokesRepository, JokesRepository>();

        services.AddAutoMapper(typeof(PortfolioWebAppAutoMapperProfileConfiguration));
    }
}