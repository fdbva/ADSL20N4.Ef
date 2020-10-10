using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public class LivroService : ILivroService
    {
        public async Task<IEnumerable<LivroEntity>> GetAllAsync(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<LivroEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(LivroEntity livroEntity)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(LivroEntity livroEntity)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(LivroEntity livroEntity)
        {
            throw new NotImplementedException();
        }
    }
}
