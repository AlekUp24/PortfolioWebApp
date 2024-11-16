using Microsoft.AspNetCore.Components;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Components.Pages
{
    public partial class IdeaEdit
    {

        [Parameter]
        public int IdeaId { get; set; }

        public InnovationIdeas EditedIdea { get; set; }

        [Inject]
        public IInnovationIdeasRepository? innovationIdeasRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EditedIdea = await innovationIdeasRepository.GetIdeaById(IdeaId);
        }
    }
}
