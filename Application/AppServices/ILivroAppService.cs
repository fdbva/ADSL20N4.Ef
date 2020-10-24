using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.AppServices
{
    public interface ILivroAppService
    {
        //TODO: trocar para aceitar nullable
        Task<IEnumerable<LivroViewModel>> GetAllAsync(string search);
        Task<LivroViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(LivroViewModel livroViewModel);
        Task EditAsync(LivroViewModel livroViewModel);
        Task RemoveAsync(LivroViewModel livroViewModel);
        Task<bool> IsIsbnValidAsync(string isbn, int? id);
    }
}
