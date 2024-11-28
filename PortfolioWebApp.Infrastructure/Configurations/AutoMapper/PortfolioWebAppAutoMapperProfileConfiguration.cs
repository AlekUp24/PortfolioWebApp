using PortfolioWebApp.Common.Models.Ideas;
using PortfolioWebApp.Common.Models.Models;
using PortfolioWebApp.Domain.Entities.Jokes;

namespace PortfolioWebApp.Infrastructure.Configurations.AutoMapper
{
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
            CreateMap<IdeaCategoryModel, IdeaCategoryEntity>();
            CreateMap<IdeaCategoryEntity, IdeaCategoryModel>();

            CreateMap<InnovationIdeasEntity, InnovationIdeasModel>();
            CreateMap<InnovationIdeasModel, InnovationIdeasEntity>();
        }
    }
}
