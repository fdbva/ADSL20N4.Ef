using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Mvc.ViewModels;

namespace Mvc.HttpServices.Implementations
{
    public class LivroHttpService : CrudHttpService<LivroViewModel>, ILivroHttpService
    {
        private readonly HttpClient _httpClient;

        public LivroHttpService(
            HttpClient httpClient)
            : base(httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> AddAsync(LivroAutorCreateViewModel livroAutorCreateViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync($"LivroAutorCreate", livroAutorCreateViewModel);

            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();

            var id = int.Parse(contentString);

            return id;
        }

        public async Task<bool> IsIsbnValidAsync(string isbn, int? id)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            var isIsbnValid = await _httpClient
                .GetFromJsonAsync<bool>($"IsIsbnValid/{isbn}/{id}");
            return isIsbnValid;
        }
    }
}
