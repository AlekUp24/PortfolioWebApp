namespace PortfolioWebApp.Domain.Entities.Ideas
{
    public class InnovationIdeasEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name is too long. (must be <50)")]
        public string Name { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Description is too long. (must be <150)")]
        public string Description { get; set; }
        public IdeaCategoryEntity Category { get; set; }
        public bool Implemented { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
