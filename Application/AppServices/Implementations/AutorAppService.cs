using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.AppServices.Implementations
{
    public class AutorAppService : IAutorAppService
    {
        public async Task<IEnumerable<AutorViewModel>> GetAllAsync(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<AutorViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(AutorViewModel autorViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(AutorViewModel autorViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(AutorViewModel autorViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
