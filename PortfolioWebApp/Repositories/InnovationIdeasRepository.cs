using Microsoft.EntityFrameworkCore;
using PortfolioWebApp.Contracts;
using PortfolioWebApp.Data;
using PortfolioWebApp.Models;

namespace PortfolioWebApp.Repositories
{
    public class InnovationIdeasRepository: IInnovationIdeasRepository, IDisposable
    {
        public readonly AppDbContext _appDbContext;

        public InnovationIdeasRepository(IDbContextFactory<AppDbContext> DbFactory)
        {
            _appDbContext = DbFactory.CreateDbContext();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }

        public async Task<IEnumerable<InnovationIdeas>> GetAllIdeas()
        {
            return await _appDbContext.InnovationIdeas.OrderByDescending(idea => idea.LastUpdated).ToListAsync();
        }

        public async Task<InnovationIdeas> GetIdeaById (int ideaId)
        {
            return await _appDbContext.InnovationIdeas.FirstOrDefaultAsync(idea => idea.Id == ideaId);
        }

        public async Task<InnovationIdeas> AddToIdeas(InnovationIdeas idea)
        {

            var existingRecord = await _appDbContext.InnovationIdeas.FirstOrDefaultAsync(w =>
                                       w.Name == idea.Name
                                    && w.Description == idea.Description
                                    && w.Category == idea.Category
                                    );

            if (existingRecord != null) 
            {
                Console.WriteLine("Duplicate entry found, not adding to DB");
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

        public async Task ChangeStatus(InnovationIdeas idea)
        {
            idea.Implemented = !idea.Implemented;
            idea.LastUpdated = DateTime.Now;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task RefreshLastUpdated(InnovationIdeas idea)
        {
            idea.LastUpdated = DateTime.Now;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
