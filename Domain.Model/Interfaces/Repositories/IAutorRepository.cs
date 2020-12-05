using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IAutorRepository : IBaseRepository<AutorEntity>
    {
        Task<IEnumerable<AutorEntity>> GetAllAsync(string searchName);
    }
}
