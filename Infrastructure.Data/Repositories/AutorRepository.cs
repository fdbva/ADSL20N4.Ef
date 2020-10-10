using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;

namespace Infrastructure.Data.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        public async Task<IEnumerable<AutorEntity>> GetAllAsync(string search)
        {
            throw new NotImplementedException();
        }

        public async Task<AutorEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> AddAsync(AutorEntity autorEntity)
        {
            throw new NotImplementedException();
        }

        public async Task EditAsync(AutorEntity autorEntity)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(AutorEntity autorEntity)
        {
            throw new NotImplementedException();
        }
    }
}
