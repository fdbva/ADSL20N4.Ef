using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public class LivroService : ILivroService
    {
        private readonly IAutorRepository _autorRepository;
        private readonly ILivroRepository _livroRepository;

        public LivroService(
            IAutorRepository autorRepository,
            ILivroRepository livroRepository)
        {
            _autorRepository = autorRepository;
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

        public async Task<int> AddAsync(LivroAutorCreateModel livroAutorCreateModel)
        {
            using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var autorId = livroAutorCreateModel.AutorId ?? 0;
            if (livroAutorCreateModel.AutorId is null || livroAutorCreateModel.AutorId < 1)
            {
                var autorEntity = livroAutorCreateModel.ToAutorEntity();

                autorId = await _autorRepository.AddAsync(autorEntity);
            }

            var livroEntity = livroAutorCreateModel.ToLivroEntity();
            livroEntity.AutorId = autorId;

            var livroId =  await _livroRepository.AddAsync(livroEntity);

            transactionScope.Complete();

            return livroId;
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

            if (livroDoIsbn is null)
                return true;

            return livroDoIsbn.Id == id;
        }
    }
}
