using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioWebApp.Application.Features.Ideas.Handlers
{
    public class IdeasChangeStatusCommandHandler : IRequestHandler<IdeasChangeStatusCommand, int>
    {
        private readonly IInnovationIdeasRepository _repository;
        private readonly IMapper _mapper;

        public IdeasChangeStatusCommandHandler(IInnovationIdeasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(IdeasChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var toUpdate = _mapper.Map<InnovationIdeasModel, InnovationIdeasEntity>(request.Idea);
            await _repository.ChangeStatus(toUpdate);
            return 200;
        }
    }
    
}
