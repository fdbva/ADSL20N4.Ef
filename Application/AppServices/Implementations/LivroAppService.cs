using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.AppServices.Implementations
{
    public class LivroAppService : ILivroAppService
    {
        public async Task<IEnumerable<LivroViewModel>> GetAllAsync(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<LivroViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(LivroViewModel livroViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(LivroViewModel livroViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(LivroViewModel livroViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
