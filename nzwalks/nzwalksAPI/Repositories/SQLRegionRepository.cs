using Microsoft.EntityFrameworkCore;
using nzwalks.API.Data;
using nzwalks.API.Models.Domain;

namespace nzwalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly nzwalksdbcontext _dbcontext;

        public SQLRegionRepository(nzwalksdbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
           return await _dbcontext.Regions.ToListAsync();
        }

        public async Task<Region> GetByCode(string name)
        {
            return await _dbcontext.Regions.FirstOrDefaultAsync(x => x.Code == name);
        }

        public async Task<Region> GetByIDAsync(Guid id)
        {
            return await _dbcontext.Regions.FindAsync(id);
        }
    }
}
