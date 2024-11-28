namespace PortfolioWebApp.Data.Ideas
{
    public class IdeaShowBase: MainBase
    {
        public IEnumerable<InnovationIdeasModel> AllIdeas { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AllIdeas = await IdeasShowService.GetAllIdeas();
        }

        public async Task ChangeStatus(InnovationIdeasModel idea)
        {
            await IdeasShowService.ChangeStatus(idea);
            AllIdeas = await IdeasShowService.GetAllIdeas();
        }

        public async Task DeleteIdea(int ideaId)
        {
            await IdeaEditService.DeleteIdea(ideaId);
            AllIdeas = await IdeasShowService.GetAllIdeas();
        }

        public void NavigateToEdit(int ideaId)
        {
            NavigationManager.NavigateTo($"/IdeaEdit/{ideaId}");
        }
    }
}
