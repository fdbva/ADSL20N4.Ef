using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Mvc.ViewModels;

namespace Mvc.HttpServices.Implementations
{
    public abstract class CrudHttpService<TViewModel> : ICrudHttpService<TViewModel>
        where TViewModel : BaseViewModel
    {
        private readonly HttpClient _httpClient;

        protected CrudHttpService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAllAsync(string search)
        {
            var viewModels = await _httpClient.GetFromJsonAsync<IEnumerable<TViewModel>>(search);

            return viewModels;
        }

        public virtual async Task<TViewModel> GetByIdAsync(int id)
        {
            var viewModel = await _httpClient.GetFromJsonAsync<TViewModel>($"GetById/{id}");

            return viewModel;
        }

        public virtual async Task<int> AddAsync(TViewModel viewModel)
        {
            var response = await _httpClient.PostAsJsonAsync(string.Empty, viewModel);

            response.EnsureSuccessStatusCode();

            var contentString = await response.Content.ReadAsStringAsync();

            var id = int.Parse(contentString);

            return id;
        }

        public virtual async Task EditAsync(TViewModel viewModel)
        {
            var response = await _httpClient.PutAsJsonAsync($"{viewModel.Id}", viewModel);

            response.EnsureSuccessStatusCode();
        }

        public virtual async Task RemoveAsync(TViewModel viewModel)
        {
            var response = await _httpClient.DeleteAsync($"{viewModel.Id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
