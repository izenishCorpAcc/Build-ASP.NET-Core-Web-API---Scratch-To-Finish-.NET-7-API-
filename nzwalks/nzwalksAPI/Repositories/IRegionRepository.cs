using nzwalks.API.Models.Domain;

namespace nzwalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
    }
}
