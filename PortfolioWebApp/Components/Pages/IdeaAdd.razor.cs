using Microsoft.AspNetCore.Components;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Components.Pages
{
    public partial class IdeaAdd
    {
        [Inject]
        public IInnovationIdeasRepository? innovationIdeasRepository { get; set; }

        private InnovationIdeas model = new InnovationIdeas();

        [SupplyParameterFromForm]
        protected string Name { get; set; }
        [SupplyParameterFromForm]
        protected string Description { get; set; }
        [SupplyParameterFromForm]
        protected IdeaCategory Category { get; set; }
        [SupplyParameterFromForm]
        protected bool Implemented { get; set; }
        [SupplyParameterFromForm]
        public DateTime CreationTime { get; set; }
        [SupplyParameterFromForm]
        public DateTime LastUpdated { get; set; }

        private bool isNewSubmission { get; set; } 

        protected override void OnInitialized()
        {
            isNewSubmission = true;
        }

        private async Task AddIdeaFromForm()
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else
            {
                model.name = Name;
                model.description = Description;
                model.category = Category;
                model.implemented = false;
                model.CreationTime = DateTime.Now;
                model.LastUpdated = DateTime.Now;

                await innovationIdeasRepository.AddToIdeas(model);
                isNewSubmission = false;
            }
        }
    }
}
