using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public abstract class CrudService<TEntity> : ICrudService<TEntity>
        where TEntity : BaseEntity
    {
        private readonly ICrudRepository<TEntity> _crudRepository;

        protected CrudService(
            ICrudRepository<TEntity> crudRepository)
        {
            _crudRepository = crudRepository;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(string search)
        {
            return await _crudRepository.GetAllAsync(search);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _crudRepository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _crudRepository.GetByIdAsync(id);
        }

        public virtual async Task<int> AddAsync(TEntity entity)
        {
            return await _crudRepository.AddAsync(entity);
        }

        public virtual async Task EditAsync(TEntity entity)
        {
            await _crudRepository.EditAsync(entity);
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            await _crudRepository.RemoveAsync(entity);
        }
    }
}
