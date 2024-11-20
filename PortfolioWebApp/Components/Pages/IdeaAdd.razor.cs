using Microsoft.AspNetCore.Components;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebApp.Components.Pages
{
    public partial class IdeaAdd
    {
        [Inject]
        public IInnovationIdeasRepository? innovationIdeasRepository { get; set; }

        //private InnovationIdeas model = new InnovationIdeas();

        //[Required]
        //[StringLength(100, ErrorMessage = "Name is too long. (must be <100)")]
        //[SupplyParameterFromForm]
        //protected string Name { get; set; }

        [SupplyParameterFromForm]
        public InnovationIdeas model { get; set; } = new InnovationIdeas();

        //[SupplyParameterFromForm]
        //protected string Description { get; set; }

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
                //model.Name = Name;
                //model.Description = Description;
                model.Category = Category;
                model.Implemented = false;
                model.CreationTime = DateTime.Now;
                model.LastUpdated = DateTime.Now;

                await innovationIdeasRepository.AddToIdeas(model);
                isNewSubmission = false;
            }
        }
        private async Task ResetView()
        {
            isNewSubmission = true;
            model = new InnovationIdeas();
        }
    }
}
