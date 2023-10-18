using nzwalks.API.Models.Domain;

namespace nzwalks.API.Repositories
{
    public interface IRegionRepository
    {
     
        //Get all Regions
        Task<List<Region>> GetAllAsync();
        //Get by ID
        Task<Region> GetByIDAsync(Guid id);

        //Get by Region Code
        Task<Region> GetByCode(string name);

        //Insert a Region
        Task<Region> CreateAsync(Region region);
                   
        //Update a Region
        Task<Region?> UpdateAsync(Guid id,Region region);

        //Delete a Region
        Task<Region?> DeleteAsync(Guid id); 
    }
}
