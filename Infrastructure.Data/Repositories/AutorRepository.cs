using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;

        public AutorRepository(
            BibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }

        public async Task<IEnumerable<AutorEntity>> GetAllAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return _bibliotecaContext.Autores;
            }

            return _bibliotecaContext.Autores.Where(x => x.Nome.Contains(search));
        }

        public async Task<AutorEntity> GetByIdAsync(int id)
        {
            return await _bibliotecaContext.Autores.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddAsync(AutorEntity autorEntity)
        {
            var entityEntry = await _bibliotecaContext.Autores.AddAsync(autorEntity);

            await _bibliotecaContext.SaveChangesAsync();

            return entityEntry.Entity.Id;
        }

        public async Task EditAsync(AutorEntity autorEntity)
        {
            _bibliotecaContext.Autores.Update(autorEntity);

            await _bibliotecaContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(AutorEntity autorEntity)
        {
            var autorToRemove = await GetByIdAsync(autorEntity.Id);

            _bibliotecaContext.Autores.Remove(autorToRemove);

            await _bibliotecaContext.SaveChangesAsync();
        }
    }
}
