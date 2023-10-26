using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nzwalks.API.Data;
using nzwalks.API.Models.Domain;
using nzwalks.API.Models.DTO;
using nzwalks.API.Repositories;

namespace nzwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly nzwalksdbcontext _dbcontext;
        private readonly IRegionRepository _iRR;
        private readonly IMapper _mapper;

        public RegionController(nzwalksdbcontext dbcontext,IRegionRepository IRR,IMapper mapper)
        {
            _dbcontext = dbcontext;
            _iRR = IRR;
            _mapper = mapper;
        }
        //private readonly List<Region> regions = new List<Region>
        //    {
        //        new Region
        //        {
        //            id=Guid.NewGuid(),
        //            Name="PoonHill",
        //            Code="PHL",
        //            RegionImageUrl="https://th.bing.com/th/id/OIP.1xTcEJX8S_RFHKnl_fGavQHaEo?w=296&h=185&c=7&r=0&o=5&pid=1.7"
        //        },
        //           new Region
        //        {
        //            id=Guid.NewGuid(),
        //            Name="Ghandruk",
        //            Code="GRK",
        //            RegionImageUrl="https://th.bing.com/th/id/OIP.EafU5y43CfLKskEA-TJdjgHaFj?w=249&h=187&c=7&r=0&o=5&pid=1.7"
        //        },
        //    };

        //Get all Records
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            //Get Data from the database-Domain Model
            var result =await _iRR.GetAllAsync();

            //Map Domain Model to DTO's
            //var regionsDTO = new List<regiondto>();
            //foreach (var r in result)
            //{
            //    regionsDTO.Add(new regiondto()
            //    {
            //        id = r.id,
            //        Code = r.Code,
            //        Name = r.Name,
            //        RegionImageUrl = r.RegionImageUrl
            //    });   
            //}

            var regionsDTO=_mapper.Map<List<regiondto>>(result);

            //Return DTO's
            return Ok(regionsDTO);

        }

        //Get by CODEID
        [HttpGet("{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {

            //var result=await _dbcontext.Regions.FirstOrDefaultAsync(r=>r.Code==code);
            var result=await _iRR.GetByCode(code);
            if(result == null)
            {
                return NotFound();
            }

            var regionsDTO = new regiondto
            {
                id = result.id,
                Code = result.Code,
                Name = result.Name,
                RegionImageUrl = result.RegionImageUrl
            };
            return Ok(regionsDTO);
             
        }

        //or
        //GET BY ID
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var region =await _iRR.GetByIDAsync(id);
            if(region == null)
            {
                return NotFound();
            }
            
            var regionsdto = new regiondto
            {
                id = region.id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(regionsdto);
         }

        //CREATE A RECORD
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] addregiondto AR)
        {
            //MAP or create DTO to DOMAIN MODEL
            var regionDomainModel = new Region
            {
                Code = AR.Code,
                Name = AR.Name,
                RegionImageUrl = AR.RegionImageUrl
            };
            //await _dbcontext.Regions.AddAsync(regionDomainModel);
            //await _dbcontext.SaveChangesAsync();
            _iRR.CreateAsync(regionDomainModel);

            //MAP domainModel back to dto
            var regionsDTO = new regiondto
            {
                id = regionDomainModel.id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetById),new {id=regionsDTO.id},regionsDTO);
        }

      //UPDATE A RECORD BY ID
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,[FromBody]updateregiondto updater)
        {
            //DTO to domain model
            var up2model = new Region
            {
                Code = updater.Code,
                Name = updater.Name,
                RegionImageUrl = updater.RegionImageUrl
            };
            //Check if regions exist
            var result = await _iRR.UpdateAsync(id, up2model);
            
            if (result == null)
            {
                return NotFound();
            }

            //result.Code = updater.Code;
            //result.Name = updater.Name;
            //result.RegionImageUrl = updater.RegionImageUrl;

            //await _dbcontext.SaveChangesAsync();

            //Convert domain model to DTO
            var regionsDTO = new regiondto
            {
                id = result.id,
                Code = result.Code,
                Name = result.Name,
                RegionImageUrl = result.RegionImageUrl
            };
            //return CreatedAtAction(nameof(GetById),new {id=regionsDTO.id},regionsDTO);
            return Ok(regionsDTO); // Use Ok() to return a 200 (OK) status code for a successful update.

        }

        //DELETE A RECORD BY ID
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result=await _iRR.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }

           
            return Ok(result);

        }


    }
}

