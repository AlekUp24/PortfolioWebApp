namespace PortfolioWebApp.Models
{
    public class InnovationIdeas
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public IdeaCategory category { get; set; }
        public bool implemented { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
