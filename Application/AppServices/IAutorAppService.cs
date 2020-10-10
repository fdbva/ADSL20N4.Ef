using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.AppServices
{
    public interface IAutorAppService
    {
        Task<IEnumerable<AutorViewModel>> GetAllAsync(string search);
        Task<AutorViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(AutorViewModel autorViewModel);
        Task EditAsync(AutorViewModel autorViewModel);
        Task RemoveAsync(AutorViewModel autorViewModel);
    }
}
