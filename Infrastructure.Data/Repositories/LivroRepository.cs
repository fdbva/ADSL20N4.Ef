using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;

        public LivroRepository(
            BibliotecaContext bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }

        public async Task<IEnumerable<LivroEntity>> GetAllAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return _bibliotecaContext.Livros;
            }

            return _bibliotecaContext.Livros.Where(x => x.Titulo.Contains(search));
        }

        public async Task<LivroEntity> GetByIdAsync(int id)
        {
            return await _bibliotecaContext.Livros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddAsync(LivroEntity livroEntity)
        {
            var entityEntry = await _bibliotecaContext.Livros.AddAsync(livroEntity);

            await _bibliotecaContext.SaveChangesAsync();

            return entityEntry.Entity.Id;
        }

        public async Task EditAsync(LivroEntity livroEntity)
        {
            _bibliotecaContext.Livros.Update(livroEntity);

            await _bibliotecaContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(LivroEntity livroEntity)
        {
            var livroToRemove = await GetByIdAsync(livroEntity.Id);

            _bibliotecaContext.Livros.Remove(livroToRemove);

            await _bibliotecaContext.SaveChangesAsync();
        }
    }
}
