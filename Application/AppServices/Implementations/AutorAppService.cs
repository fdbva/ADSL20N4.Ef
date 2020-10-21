using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;
using AutoMapper;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;

namespace Application.AppServices.Implementations
{
    public class AutorAppService : IAutorAppService
    {
        private readonly IMapper _mapper;
        private readonly IAutorService _autorService;

        public AutorAppService(
            IMapper mapper,
            IAutorService autorService)
        {
            _mapper = mapper;
            _autorService = autorService;
        }

        public async Task<IEnumerable<AutorViewModel>> GetAllAsync(string search)
        {
            var autorEntities = await _autorService.GetAllAsync(search);

            return _mapper.Map<IEnumerable<AutorViewModel>>(autorEntities);
        }

        public async Task<AutorViewModel> GetByIdAsync(int id)
        {
            var autorEntity = await _autorService.GetByIdAsync(id);

            return _mapper.Map<AutorViewModel>(autorEntity);
        }

        public async Task<int> AddAsync(AutorViewModel autorViewModel)
        {
            var autorEntity = _mapper.Map<AutorEntity>(autorViewModel);

            var id = await _autorService.AddAsync(autorEntity);

            return id;
        }

        public async Task EditAsync(AutorViewModel autorViewModel)
        {
            var autorEntity = _mapper.Map<AutorEntity>(autorViewModel);

            await _autorService.EditAsync(autorEntity);
        }

        public async Task RemoveAsync(AutorViewModel autorViewModel)
        {
            var autorEntity = _mapper.Map<AutorEntity>(autorViewModel);

            await _autorService.RemoveAsync(autorEntity);
        }
    }
}
