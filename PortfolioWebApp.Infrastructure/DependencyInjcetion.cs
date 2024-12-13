namespace PortfolioWebApp.Infrastructure;

public static class DependencyInjcetion
{
    public static void AddInfrustructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IWeatherRepository, WeatherRepository>();
        services.AddScoped<IInnovationIdeasRepository, InnovationIdeasRepository>();
        services.AddScoped<IJokesRepository, JokesRepository>();

        services.AddHttpClient("PortfolioApi", client => {
                client.BaseAddress = new Uri(configuration["BaseUri"]!);
                }
            );


        services.AddAutoMapper(typeof(PortfolioWebAppAutoMapperProfileConfiguration));

    }
}