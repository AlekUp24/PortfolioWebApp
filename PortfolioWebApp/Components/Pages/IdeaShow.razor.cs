﻿using Microsoft.AspNetCore.Components;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Components.Pages
{
    public partial class IdeaShow
    {
        [Inject]
        public IInnovationIdeasRepository? innovationIdeasRepository { get; set; }

        private IEnumerable<InnovationIdeas> AllIdeas { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AllIdeas = await innovationIdeasRepository.GetAllIdeas();
        }

        private async Task ChangeStatus(InnovationIdeas idea)
        {
            await innovationIdeasRepository.ChangeStatus(idea);
        }
    }
}