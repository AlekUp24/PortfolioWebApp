using Microsoft.Extensions.Logging;

namespace PortfolioWebApp.Infrastructure.Repositories.Ideas
{
    public class InnovationIdeasRepository : IInnovationIdeasRepository, IDisposable
    {
        public readonly AppDbContext _appDbContext;
        private readonly ILogger<InnovationIdeasRepository> _logger;

        public InnovationIdeasRepository(IDbContextFactory<AppDbContext> DbFactory, ILogger<InnovationIdeasRepository> logger)
        {
            _appDbContext = DbFactory.CreateDbContext();
            _logger = logger;
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public async Task<IEnumerable<InnovationIdeasEntity>> GetAllIdeas()
        {
            return await _appDbContext.InnovationIdeas.OrderByDescending(idea => idea.LastUpdated).ToListAsync();
        }

        public async Task<InnovationIdeasEntity> GetIdeaById(int ideaId)
        {
            return await _appDbContext.InnovationIdeas.FirstOrDefaultAsync(idea => idea.Id == ideaId);
        }

        public async Task<InnovationIdeasEntity> AddToIdeas(InnovationIdeasEntity idea)
        {

            var existingRecord = await _appDbContext.InnovationIdeas.FirstOrDefaultAsync(w =>
                                       w.Name == idea.Name
                                    && w.Description == idea.Description
                                    && w.Category == idea.Category
                                    );

            if (existingRecord != null)
            {
                _logger.LogInformation("Duplicate entry found, not adding to DB");
                return existingRecord;
            }
            else
            {
                var toBeAdded = await _appDbContext.InnovationIdeas.AddAsync(idea);
                await _appDbContext.SaveChangesAsync();

                return toBeAdded.Entity;
            }

        }

        public async Task DeleteIdea(int ideaId)
        {
            var toDelete = await GetIdeaById(ideaId);
            _appDbContext.InnovationIdeas.Remove(toDelete);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task ChangeStatus(InnovationIdeasEntity idea)
        {
            InnovationIdeasEntity ideaToEdit = await GetIdeaById(idea.Id);

            ideaToEdit.Implemented = !ideaToEdit.Implemented;
            ideaToEdit.LastUpdated = DateTime.Now;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task RefreshLastUpdated(InnovationIdeasEntity idea)
        {
            InnovationIdeasEntity ideaToEdit = await GetIdeaById(idea.Id);
            
            ideaToEdit.Name = idea.Name;
            ideaToEdit.Description = idea.Description;
            ideaToEdit.Category = idea.Category;
            ideaToEdit.LastUpdated = DateTime.Now;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
