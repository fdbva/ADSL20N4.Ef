using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public abstract class CrudRepository<TEntity> : ICrudRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly BibliotecaContext BibliotecaContext;
        protected readonly DbSet<TEntity> DbSet;

        protected CrudRepository(
            BibliotecaContext bibliotecaContext)
        {
            BibliotecaContext = bibliotecaContext;
            DbSet = bibliotecaContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return DbSet;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<int> AddAsync(TEntity entity)
        {
            var entityEntry = await DbSet.AddAsync(entity);

            return entityEntry.Entity.Id;
        }

        public virtual async Task EditAsync(TEntity entity)
        {
            var entityToUpdate = await GetByIdAsync(entity.Id);

            BibliotecaContext
                .Entry(entityToUpdate)
                .CurrentValues.
                SetValues(entity);
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            var entityToRemove = await GetByIdAsync(entity.Id);

            DbSet.Remove(entityToRemove);
        }
    }
}
