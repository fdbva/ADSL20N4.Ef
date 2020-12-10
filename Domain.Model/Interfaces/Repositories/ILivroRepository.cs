using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Repositories
{
    public interface ILivroRepository : ICrudRepository<LivroEntity>
    {
        Task<LivroEntity> GetByIsbnAsync(string isbn);
    }
}
