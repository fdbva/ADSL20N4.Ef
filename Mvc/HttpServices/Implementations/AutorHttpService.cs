using System.Net.Http;
using Mvc.ViewModels;

namespace Mvc.HttpServices.Implementations
{
    public class AutorHttpService : CrudHttpService<AutorViewModel>, IAutorHttpService
    {
        public AutorHttpService(
            HttpClient httpClient)
            : base(httpClient)
        {
        }
    }
}
