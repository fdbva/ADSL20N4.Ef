using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;
using AutoMapper;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Application.AppServices.Implementations
{
    public class LivroAppService : ILivroAppService
    {
        private readonly IMapper _mapper;
        private readonly ILivroService _livroService;

        public LivroAppService(
            IMapper mapper,
            ILivroService livroService)
        {
            _mapper = mapper;
            _livroService = livroService;
        }

        public async Task<IEnumerable<LivroViewModel>> GetAllAsync(string search)
        {
            var livroEntities = await _livroService.GetAllAsync(search);

            return _mapper.Map<IEnumerable<LivroViewModel>>(livroEntities);
        }

        public async Task<LivroViewModel> GetByIdAsync(int id)
        {
            var livroEntity = await _livroService.GetByIdAsync(id);

            return _mapper.Map<LivroViewModel>(livroEntity);
        }

        public async Task<int> AddAsync(LivroViewModel livroViewModel)
        {
            var livroEntity = _mapper.Map<LivroEntity>(livroViewModel);

            var id = await _livroService.AddAsync(livroEntity);

            return id;
        }

        public async Task EditAsync(LivroViewModel livroViewModel)
        {
            var livroEntity = _mapper.Map<LivroEntity>(livroViewModel);

            await _livroService.EditAsync(livroEntity);
        }

        public async Task RemoveAsync(LivroViewModel livroViewModel)
        {
            var livroEntity = _mapper.Map<LivroEntity>(livroViewModel);

            await _livroService.RemoveAsync(livroEntity);
        }

        public async Task<bool> IsIsbnValidAsync(string isbn, int? id)
        {
            return await _livroService.IsIsbnValidAsync(isbn, id);
        }
    }
}
