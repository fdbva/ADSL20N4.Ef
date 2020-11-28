﻿using System.Collections.Generic;
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
            var livrosComAutores = _bibliotecaContext
                .Livros
                .Include(x => x.Autor);

            if (string.IsNullOrWhiteSpace(search))
            {
                return livrosComAutores;
            }

            return livrosComAutores.Where(x => x.Titulo.Contains(search));
        }

        public async Task<LivroEntity> GetByIdAsync(int id)
        {
            return await _bibliotecaContext.Livros
                .Include(x => x.Autor)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> AddAsync(LivroEntity livroEntity)
        {
            var entityEntry = await _bibliotecaContext.Livros.AddAsync(livroEntity);

            return entityEntry.Entity.Id;
        }

        public async Task EditAsync(LivroEntity livroEntity)
        {
            var livroToUpdate = await GetByIdAsync(livroEntity.Id);

            _bibliotecaContext
                .Entry(livroToUpdate)
                .CurrentValues.
                SetValues(livroEntity);
        }

        public async Task RemoveAsync(LivroEntity livroEntity)
        {
            var livroToRemove = await GetByIdAsync(livroEntity.Id);

            _bibliotecaContext.Livros.Remove(livroToRemove);
        }

        public async Task<LivroEntity> GetByIsbnAsync(string isbn)
        {
            return await _bibliotecaContext.Livros
                .FirstOrDefaultAsync(x => x.Isbn == isbn);
        }
    }
}
