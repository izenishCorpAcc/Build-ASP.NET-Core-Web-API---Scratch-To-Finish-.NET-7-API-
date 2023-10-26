using AutoMapper;
using nzwalks.API.Models.Domain;
using nzwalks.API.Models.DTO;

namespace nzwalks.API.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,regiondto>().ReverseMap();
        }
    }
}
