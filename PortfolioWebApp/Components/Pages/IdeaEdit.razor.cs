using Microsoft.AspNetCore.Components;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Components.Pages
{
    public partial class IdeaEdit
    {

        [Parameter]
        public int IdeaId { get; set; }

        [SupplyParameterFromForm]
        public InnovationIdeas EditedIdea { get; set; } = new();


        [Inject]
        public IInnovationIdeasRepository? innovationIdeasRepository { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EditedIdea = await innovationIdeasRepository.GetIdeaById(IdeaId);
        }

        private async Task DeleteIdea(int ideaId)
        {
            await innovationIdeasRepository.DeleteIdea(ideaId);
            NavigationManager.NavigateTo("/IdeaShow");
        }
        
        private async Task NavigateToIdeaShow()
        {
            innovationIdeasRepository.RefreshLastUpdated(EditedIdea);
            NavigationManager.NavigateTo("/IdeaShow");
        }
    }
}
