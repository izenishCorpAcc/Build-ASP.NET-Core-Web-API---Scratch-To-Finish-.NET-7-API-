using Microsoft.EntityFrameworkCore;
using nzwalks.API.Data;
using nzwalks.API.Models.Domain;
using nzwalks.API.Models.DTO;

namespace nzwalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly nzwalksdbcontext _dbcontext;

        public SQLRegionRepository(nzwalksdbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            //var Result= await _dbcontext.Regions.AddAsync(region);
            //await _dbcontext.SaveChangesAsync();
            //return Result.Entity;
            //or
            await _dbcontext.Regions.AddAsync(region);
            await _dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var result = await _dbcontext.Regions.FirstOrDefaultAsync(x => x.id == id);
            if (result == null)
            {
                return null;
            }
             _dbcontext.Regions.Remove(result);
            await _dbcontext.SaveChangesAsync();
            return result;
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

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var result = await _dbcontext.Regions.FirstOrDefaultAsync(x => x.id == id);
            if (result == null)
            {
                return null;
            }

            result.Code=region.Code;
            result.Name=region.Name;
            result.RegionImageUrl=region.RegionImageUrl;
            await _dbcontext.SaveChangesAsync();
            return result;
            
        }
    }
}
