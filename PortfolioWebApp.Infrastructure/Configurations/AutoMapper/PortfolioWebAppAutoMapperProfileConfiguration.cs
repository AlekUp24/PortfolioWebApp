namespace PortfolioWebApp.Infrastructure.Configurations.AutoMapper;

public class PortfolioWebAppAutoMapperProfileConfiguration : Profile
{
    public PortfolioWebAppAutoMapperProfileConfiguration() : this("portfolioApp.profile") 
    { 
    }

    protected PortfolioWebAppAutoMapperProfileConfiguration(string profileName) : base(profileName) 
    {
        //Jokes
        CreateMap<JokesResponseModel, JokesResponseEntity>();
        CreateMap<JokesResponseEntity, JokesResponseModel>();

        //Weather
        CreateMap<WeatherHistoryEntity, WeatherHistoryModel>();
        CreateMap<WeatherHistoryModel, WeatherHistoryEntity>();

        //Ideas
        CreateMap<InnovationIdeasEntity, InnovationIdeasModel>();
        CreateMap<InnovationIdeasModel, InnovationIdeasEntity>();
    }
}