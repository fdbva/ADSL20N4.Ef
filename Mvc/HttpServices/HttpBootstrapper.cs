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
            //TODO: Melhorar esse endereço mágico
            services.AddHttpClient<IAutorHttpService, AutorHttpService>(x => x.BaseAddress = new Uri("https://localhost:44366/api/autor/"));
            services.AddHttpClient<ILivroHttpService, LivroHttpService>(x => x.BaseAddress = new Uri("https://localhost:44366/api/livro/"));
        }
    }
}
