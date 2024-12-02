namespace PortfolioWebApp.Data.Ideas
{
    public class IdeaAddBase : MainBase
    {

        [SupplyParameterFromForm]
        public InnovationIdeasModel Model { get; set; } = new InnovationIdeasModel();

        [SupplyParameterFromForm]
        protected IdeaCategoryEnum Category { get; set; }

        [SupplyParameterFromForm]
        protected bool Implemented { get; set; }

        [SupplyParameterFromForm]
        public DateTime CreationTime { get; set; }

        [SupplyParameterFromForm]
        public DateTime LastUpdated { get; set; }

        public bool isNewSubmission { get; set; }

        protected override void OnInitialized()
        {
            isNewSubmission = true;
        }

        public async Task AddIdeaFromForm()
        {
            if (Model == null)
            {
                throw new ArgumentNullException(nameof(Model));
            }
            else
            {
                Model.Category = Category;
                Model.Implemented = false;
                Model.CreationTime = DateTime.Now;
                Model.LastUpdated = DateTime.Now;

                isNewSubmission = false;
                await IdeaAddService.AddToIdeas(Model);
                
            }
        }

        public async Task ResetView()
        {
            isNewSubmission = true;
            Model = new InnovationIdeasModel();
        }
    }
}
