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
    }
}
