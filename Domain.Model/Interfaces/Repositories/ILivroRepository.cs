using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Repositories
{
    public interface ILivroRepository
    {
        Task<IEnumerable<LivroEntity>> GetAllAsync(string search);
        Task<LivroEntity> GetByIdAsync(int id);
        Task<int> AddAsync(LivroEntity livroEntity);
        Task EditAsync(LivroEntity livroEntity);
        Task RemoveAsync(LivroEntity livroEntity);
    }
}
