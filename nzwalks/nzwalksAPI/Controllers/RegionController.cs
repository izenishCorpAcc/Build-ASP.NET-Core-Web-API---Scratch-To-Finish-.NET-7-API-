﻿using Microsoft.AspNetCore.Mvc;
using nzwalks.API.Data;
using nzwalks.API.Models.Domain;
using nzwalks.API.Models.DTO;

namespace nzwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly nzwalksdbcontext _dbcontext;
        public RegionController(nzwalksdbcontext dbcontext)
        {
            _dbcontext = dbcontext;
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

        [HttpGet]
        public IActionResult Getall()
        {
           
            //Get Data from the database-Domain Model
            var result=_dbcontext.Regions.ToList();

            //Map Domain Model to DTO's
            var regionsDTO = new List<regiondto>();
            foreach (var r in result)
            {
                regionsDTO.Add(new regiondto()
                {
                    id = r.id,
                    Code = r.Code,
                    Name = r.Name,
                    RegionImageUrl = r.RegionImageUrl
                });   
            }

            //Return DTO's
            return Ok(regionsDTO);

        }

        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {

            var result= _dbcontext.Regions.FirstOrDefault(r=>r.Code==code);
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

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) {
            var region = _dbcontext.Regions.Find(id);
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

        [HttpPost]
        public IActionResult Create([FromBody] addregiondto AR)
        {
            //MAP or create DTO to DOMAIN MODEL
            var regionDomainModel = new Region
            {
                Code = AR.Code,
                Name = AR.Name,
                RegionImageUrl = AR.RegionImageUrl
            };
            _dbcontext.Regions.Add(regionDomainModel);
            _dbcontext.SaveChanges();

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

    }
}
