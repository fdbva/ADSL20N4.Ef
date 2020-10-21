using Application.AppServices;
using Application.AppServices.Implementations;
using AutoMapper;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Service.Services;
using Infrastructure.Crosscutting.IoC.MappingProfiles;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Crosscutting.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterBibliotecaServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<IAutorAppService, AutorAppService>();
            services.AddScoped<ILivroAppService, LivroAppService>();

            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<ILivroService, LivroService>();

            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();

            services.AddDbContext<BibliotecaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("BibliotecaContext")));

            services.AddAutoMapper(x => x.AddProfile(typeof(MappingProfile)));
        }
    }
}
