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


        public async Task<InnovationIdeas> AddToIdeas(InnovationIdeas idea)
        {

            var existingRecord = await _appDbContext.InnovationIdeas.FirstOrDefaultAsync(w =>
                                       w.name == idea.name
                                    && w.description == idea.description
                                    && w.category == idea.category
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

        public async Task ChangeStatus(InnovationIdeas idea)
        {
            idea.implemented = !idea.implemented;
            idea.LastUpdated = DateTime.Now;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
