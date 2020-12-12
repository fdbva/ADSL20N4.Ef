using System.Collections.Generic;
using System.Threading.Tasks;
using Mvc.ViewModels;

namespace Mvc.HttpServices
{
    public interface ICrudHttpService<TViewModel>
        where TViewModel : BaseViewModel
    {
        Task<IEnumerable<TViewModel>> GetAllAsync(string search);
        Task<TViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(TViewModel viewModel);
        Task EditAsync(TViewModel viewModel);
        Task RemoveAsync(TViewModel viewModel);
    }
}
