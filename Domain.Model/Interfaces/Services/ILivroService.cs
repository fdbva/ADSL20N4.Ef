using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Services
{
    public interface ILivroService
    {
        Task<IEnumerable<LivroEntity>> GetAllAsync(string search);
        Task<LivroEntity> GetByIdAsync(int id);
        Task<int> AddAsync(LivroEntity livroEntity);
        Task<int> AddAsync(LivroAutorCreateModel livroAutorCreateModel);
        Task EditAsync(LivroEntity livroEntity);
        Task RemoveAsync(LivroEntity livroEntity);
        Task<bool> IsIsbnValidAsync(string isbn, int? id);
    }
}
