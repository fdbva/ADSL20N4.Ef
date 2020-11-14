using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Mvc.ViewModels;

namespace Mvc.HttpServices.Implementations
{
    public class AutorHttpService : IAutorHttpService
    {
        private readonly HttpClient _httpClient;

        public AutorHttpService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AutorViewModel>> GetAllAsync(string search)
        {
            var autores = await _httpClient.GetFromJsonAsync<IEnumerable<AutorViewModel>>(search);

            return autores;
        }

        public async Task<AutorViewModel> GetByIdAsync(int id)
        {
            var autor = await _httpClient.GetFromJsonAsync<AutorViewModel>($"GetById/{id}");

            return autor;
        }

        public async Task<int> AddAsync(AutorViewModel autorViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync(string.Empty, autorViewModel);

            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();

            var id = int.Parse(contentString);

            return id;
        }

        public async Task EditAsync(AutorViewModel autorViewModel)
        {
            var response = await _httpClient.PutAsJsonAsync($"{autorViewModel.Id}", autorViewModel);

            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveAsync(AutorViewModel autorViewModel)
        {
            var response = await _httpClient.DeleteAsync($"{autorViewModel.Id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
