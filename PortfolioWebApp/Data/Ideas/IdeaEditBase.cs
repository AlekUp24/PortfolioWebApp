namespace PortfolioWebApp.Data.Ideas
{
    public class IdeaEditBase : MainBase
    {

        [Parameter]
        public int IdeaId { get; set; }

        [SupplyParameterFromForm]
        public InnovationIdeasModel EditedIdea { get; set; } = new InnovationIdeasModel();


        protected override async Task OnInitializedAsync()
        {
            EditedIdea = await IdeaEditService.GetIdeaById(IdeaId);
        }

        public async Task DeleteIdea(int ideaId)
        {
            await IdeaEditService.DeleteIdea(ideaId);
            NavigationManager.NavigateTo("/IdeaShow");
        }

        public async Task NavigateToIdeaShow(InnovationIdeasModel EditedIdea)
        {
            await IdeaEditService.RefreshLastUpdated(EditedIdea);
            NavigationManager.NavigateTo("/IdeaShow");
        }
    }
}
