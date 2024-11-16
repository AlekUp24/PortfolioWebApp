namespace PortfolioWebApp.Models
{
    public class InnovationIdeas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IdeaCategory Category { get; set; }
        public bool Implemented { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
