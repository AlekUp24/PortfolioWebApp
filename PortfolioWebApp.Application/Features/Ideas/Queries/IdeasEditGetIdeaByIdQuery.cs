﻿namespace PortfolioWebApp.Application.Features.Ideas.Queries
{
    public class IdeasEditGetIdeaByIdQuery : IRequest<InnovationIdeasModel>
    {
        public required int ideaId { get; set; }
    }
}