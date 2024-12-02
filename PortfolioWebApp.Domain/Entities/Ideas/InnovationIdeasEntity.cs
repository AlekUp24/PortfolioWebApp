namespace PortfolioWebApp.Domain.Entities.Ideas;

public class InnovationIdeasEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IdeaCategoryEnum Category { get; set; }
    public bool Implemented { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime LastUpdated { get; set; }
}