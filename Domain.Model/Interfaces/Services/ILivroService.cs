using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Services
{
    public interface ILivroService : ICrudService<LivroEntity>
    {
        Task<int> AddAsync(LivroAutorCreateModel livroAutorCreateModel);
        Task<bool> IsIsbnValidAsync(string isbn, int? id);
    }
}
