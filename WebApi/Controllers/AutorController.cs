using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        private readonly IMapper _mapper;

        public AutorController(
            IAutorService autorService,
            IMapper mapper)
        {
            _autorService = autorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorViewModel>>> Get(string? search)
        {
            var autorEntities = await _autorService.GetAllAsync(search);

            return Ok(_mapper.Map<IEnumerable<AutorViewModel>>(autorEntities));
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<AutorViewModel>> Get(int id)
        {
            var autorEntity = await _autorService.GetByIdAsync(id);

            return Ok(_mapper.Map<AutorViewModel>(autorEntity));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(AutorViewModel autorViewModel)
        {
            var autorEntity = _mapper.Map<AutorEntity>(autorViewModel);

            var id = await _autorService.AddAsync(autorEntity);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(AutorViewModel autorViewModel)
        {
            var autorNaoEncontrado = await _autorService.GetByIdAsync(autorViewModel.Id) is not null;

            if (autorNaoEncontrado)
            {
                return NotFound();
            }

            var autorEntity = _mapper.Map<AutorEntity>(autorViewModel);

            await _autorService.EditAsync(autorEntity);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var autorEntity = await _autorService.GetByIdAsync(id);

            if (autorEntity is null)
            {
                return NotFound();
            }

            await _autorService.EditAsync(autorEntity);

            return Ok();
        }
    }
}
