using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Services
{
    public interface IAutorService
    {
        Task<IEnumerable<AutorEntity>> GetAllAsync(string search);
        Task<AutorEntity> GetByIdAsync(int id);
        Task<int> AddAsync(AutorEntity autorEntity);
        Task EditAsync(AutorEntity autorEntity);
        Task RemoveAsync(AutorEntity autorEntity);
    }
}
