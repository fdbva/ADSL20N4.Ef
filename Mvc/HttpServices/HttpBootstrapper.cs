using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mvc.HttpServices.Implementations;

namespace Mvc.HttpServices
{
    public static class HttpBootstrapper
    {
        public static void RegisterHttpClients(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var autorAddress = configuration.GetValue<Uri>("BibliotecaApi:Autor");
            services.AddHttpClient<IAutorHttpService, AutorHttpService>(x => x.BaseAddress = autorAddress);

            var livroAddress = configuration.GetValue<Uri>("BibliotecaApi:Livro");
            services.AddHttpClient<ILivroHttpService, LivroHttpService>(x => x.BaseAddress = livroAddress);
        }
    }
}
