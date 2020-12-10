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

        public async Task<IEnumerable<TEntity>> GetAllAsync(string search)
        {
            return await _crudRepository.GetAllAsync(search);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _crudRepository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _crudRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(TEntity entity)
        {
            return await _crudRepository.AddAsync(entity);
        }

        public async Task EditAsync(TEntity entity)
        {
            await _crudRepository.EditAsync(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _crudRepository.RemoveAsync(entity);
        }
    }
}
