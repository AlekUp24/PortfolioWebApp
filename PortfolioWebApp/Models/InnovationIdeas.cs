using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebApp.Models
{
    public class InnovationIdeas
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long. (must be <50)")]
        public string Name { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Description is too long. (must be <150)")]
        public string Description { get; set; }
        public IdeaCategory Category { get; set; }
        public bool Implemented { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
