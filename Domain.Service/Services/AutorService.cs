using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(
            IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<IEnumerable<AutorEntity>> GetAllAsync(string search)
        {
            return await _autorRepository.GetAllAsync(search);
        }

        public async Task<AutorEntity> GetByIdAsync(int id)
        {
            return await _autorRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(AutorEntity autorEntity)
        {
            return await _autorRepository.AddAsync(autorEntity);
        }

        public async Task EditAsync(AutorEntity autorEntity)
        {
            await _autorRepository.EditAsync(autorEntity);
        }

        public async Task RemoveAsync(AutorEntity autorEntity)
        {
            await _autorRepository.RemoveAsync(autorEntity);
        }
    }
}
