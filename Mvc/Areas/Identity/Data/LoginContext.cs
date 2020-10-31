using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Areas.Identity.Data
{
    public class LoginContext : IdentityDbContext<IdentityUser>
    {
        //Add-Migration [Nome] -context [NomeContext] -project [NomeProjetoComContext] -outputdir Areas/Identity/Data/Migrations
        ////Add-Migration InitialLoginMigration -context LoginContext -project Mvc -outputdir Areas/Identity/Data/Migrations
        public LoginContext(DbContextOptions<LoginContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
