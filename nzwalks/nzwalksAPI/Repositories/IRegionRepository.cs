using nzwalks.API.Models.Domain;

namespace nzwalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region> GetByIDAsync(Guid id);

        Task<Region> GetByCode(string name);
    }
}
