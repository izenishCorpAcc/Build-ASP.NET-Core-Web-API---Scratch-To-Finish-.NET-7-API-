using Microsoft.EntityFrameworkCore;
using nzwalks.API.Models.Domain;

namespace nzwalks.API.Data
{
    public class nzwalksdbcontext:DbContext
    {
        public nzwalksdbcontext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }
    }
}
