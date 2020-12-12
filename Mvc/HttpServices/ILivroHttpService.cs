using System.Threading.Tasks;
using Mvc.ViewModels;

namespace Mvc.HttpServices
{
    public interface ILivroHttpService : ICrudHttpService<LivroViewModel>
    {
        Task<int> AddAsync(LivroAutorCreateViewModel livroAutorCreateViewModel);
        Task<bool> IsIsbnValidAsync(string isbn, int? id);
    }
}
