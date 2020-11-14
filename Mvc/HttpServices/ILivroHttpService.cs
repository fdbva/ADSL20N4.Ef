using System.Collections.Generic;
using System.Threading.Tasks;
using Mvc.ViewModels;

namespace Mvc.HttpServices
{
    public interface ILivroHttpService
    {
        Task<IEnumerable<LivroViewModel>> GetAllAsync(string search);
        Task<LivroViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(LivroViewModel livroViewModel);
        Task EditAsync(LivroViewModel livroViewModel);
        Task RemoveAsync(LivroViewModel livroViewModel);
        Task<bool> IsIsbnValidAsync(string isbn, int? id);
    }
}
