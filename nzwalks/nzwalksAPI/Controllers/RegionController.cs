using Microsoft.AspNetCore.Mvc;
using nzwalks.API.Data;
using nzwalks.API.Models.Domain;

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
           
            var result=_dbcontext.Regions.ToList();
            return Ok(result);

        }

        [HttpGet("{code}")]
        public IActionResult Get(string code)
        {
            var result= _dbcontext.Regions.FirstOrDefault(r=>r.Code==code);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
            


    }
}
