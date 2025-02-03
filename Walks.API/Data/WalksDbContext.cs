using Microsoft.EntityFrameworkCore;
using Walks.API.Models.Domain;

namespace Walks.API.Data
{
    public class WalksDbContext : DbContext
    {
        public WalksDbContext(DbContextOptions<WalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed the data for Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("cf95d327-3650-45c2-b9a4-2e4ba3df9557"),
                    Name = "Easy"
                },
                 new Difficulty()
                 {
                    Id = Guid.Parse("9f9833a2-bc3e-44fe-8151-60986a51ac1c"),
                    Name = "Medium"
                 },
                  new Difficulty()
                  {
                    Id = Guid.Parse("e2dff0f8-488b-40bf-b48e-3fdbd4435424"),
                    Name = "Hard"
                  },
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //Seed Data for Regions

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("f683c31c-bc63-477f-8335-2b6d31133dc9"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                 new Region()
                 {
                    Id = Guid.Parse("f9abf4e7-726d-40b0-bff5-edbb7b79a280"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                 },
                  new Region()
                  {
                    Id = Guid.Parse("c3005489-95f7-41b3-8ecb-0677947df9b1"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                  },
                new Region
                {
                    Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                },

            };

            //Seed Region to the database
            modelBuilder.Entity<Region>().HasData(regions);
        }

    }
}
