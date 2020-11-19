using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mvc.Areas.Identity
{
    public static class BootstrapperIdentity
    {
        public static void RegisterAuth(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            //AddDbContext e AddDefaultIdentity estão em Areas/Identity/IdentityHostingStartup.cs

            //Comando de Migration para o LoginIdentity:
            //Add-Migration InitialLoginMigration -context LoginContext -project Mvc -outputdir Areas/Identity/Data/Migrations

            //package nuget Microsoft.AspNetCore.Authentication.Google
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    var googleAuthNSection =
                        configuration.GetSection("Authentication:Google");

                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];
                });
        }
    }
}
