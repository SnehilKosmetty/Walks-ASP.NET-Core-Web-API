using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Walks.API.Data
{
    public class WalksAuthDbContext : IdentityDbContext
    {
        public WalksAuthDbContext(DbContextOptions<WalksAuthDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "55310c93-aa3a-4c07-bd9e-0f6c0f6a5e8d";
            var writerRoleId = "715120d9-fd98-4cd9-a9a6-28333a3d6479";


            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id =writerRoleId,
                    ConcurrencyStamp=writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
