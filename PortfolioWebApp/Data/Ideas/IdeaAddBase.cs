namespace PortfolioWebApp.Data.Ideas
{
    public class IdeaAddBase : MainBase
    {

        [SupplyParameterFromForm]
        public InnovationIdeasModel model { get; set; } = new InnovationIdeasModel();

        [SupplyParameterFromForm]
        protected IdeaCategoryModel Category { get; set; }

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
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else
            {
                model.Category = Category;
                model.Implemented = false;
                model.CreationTime = DateTime.Now;
                model.LastUpdated = DateTime.Now;

                isNewSubmission = false;
                await IdeaAddService.AddToIdeas(model);
                
            }
        }

        public async Task ResetView()
        {
            isNewSubmission = true;
            model = new InnovationIdeasModel();
        }
    }
}
