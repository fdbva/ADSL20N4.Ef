using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Domain.Service.Services
{
    public class LivroService : CrudService<LivroEntity>, ILivroService
    {
        private readonly IAutorRepository _autorRepository;
        private readonly ILivroRepository _livroRepository;

        public LivroService(
            IAutorRepository autorRepository,
            ILivroRepository livroRepository)
            : base(livroRepository)
        {
            _autorRepository = autorRepository;
            _livroRepository = livroRepository;
        }

        public async Task<int> AddAsync(LivroAutorCreateModel livroAutorCreateModel)
        {
            var autorId = livroAutorCreateModel.AutorId ?? 0;
            AutorEntity autorEntity = null;
            if (livroAutorCreateModel.AutorId is null || livroAutorCreateModel.AutorId < 1)
            {
                autorEntity = livroAutorCreateModel.ToAutorEntity();

                autorId = await _autorRepository.AddAsync(autorEntity);
            }

            var livroEntity = livroAutorCreateModel.ToLivroEntity();
            livroEntity.Autor = autorEntity;

            if (autorId == 1)
            {
                throw new Exception();
            }

            var livroId =  await _livroRepository.AddAsync(livroEntity);

            return livroId;
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
