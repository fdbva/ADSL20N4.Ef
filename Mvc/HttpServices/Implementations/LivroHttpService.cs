using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Mvc.ViewModels;

namespace Mvc.HttpServices.Implementations
{
    public class LivroHttpService : ILivroHttpService
    {
        private readonly HttpClient _httpClient;

        public LivroHttpService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<LivroViewModel>> GetAllAsync(string search)
        {
            var livros = await _httpClient.GetFromJsonAsync<IEnumerable<LivroViewModel>>(search);

            return livros;
        }

        public async Task<LivroViewModel> GetByIdAsync(int id)
        {
            var livro = await _httpClient.GetFromJsonAsync<LivroViewModel>($"GetById/{id}");

            return livro;
        }

        public async Task<int> AddAsync(LivroViewModel livroViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync(string.Empty, livroViewModel);

            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();

            var id = int.Parse(contentString);

            return id;
        }

        public async Task EditAsync(LivroViewModel livroViewModel)
        {
            var response = await _httpClient.PutAsJsonAsync($"{livroViewModel.Id}", livroViewModel);

            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveAsync(LivroViewModel livroViewModel)
        {
            var response = await _httpClient.DeleteAsync($"{livroViewModel.Id}");

            response.EnsureSuccessStatusCode();
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
