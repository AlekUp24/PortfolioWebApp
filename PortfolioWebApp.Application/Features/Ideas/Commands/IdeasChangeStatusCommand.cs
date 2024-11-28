using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioWebApp.Application.Features.Ideas.Commands
{
    public class IdeasChangeStatusCommand : IRequest<int>
    {
        public required InnovationIdeasModel idea {  get; set; }
    }
}
