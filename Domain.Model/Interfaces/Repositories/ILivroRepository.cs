using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Repositories
{
    public interface ILivroRepository : ICrudRepository<LivroEntity>
    {
        Task<IEnumerable<LivroEntity>> GetAllAsync(string searchTitle);
        Task<LivroEntity> GetByIsbnAsync(string isbn);
    }
}
