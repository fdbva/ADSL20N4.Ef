using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(
            ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<LivroEntity>> GetAllAsync(string search)
        {
            return await _livroRepository.GetAllAsync(search);
        }

        public async Task<LivroEntity> GetByIdAsync(int id)
        {
            return await _livroRepository.GetByIdAsync(id);
        }

        public async Task<int> AddAsync(LivroEntity livroEntity)
        {
            return await _livroRepository.AddAsync(livroEntity);
        }

        public async Task EditAsync(LivroEntity livroEntity)
        {
            await _livroRepository.EditAsync(livroEntity);
        }

        public async Task RemoveAsync(LivroEntity livroEntity)
        {
            await _livroRepository.RemoveAsync(livroEntity);
        }

        public async Task<bool> IsIsbnValidAsync(string isbn, int? id)
        {
            var livroDoIsbn = await _livroRepository.GetByIsbnAsync(isbn);

            return livroDoIsbn?.Id == id;
        }
    }
}
