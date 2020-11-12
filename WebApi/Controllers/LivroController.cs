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
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;

        public LivroController(
            ILivroService livroService,
            IMapper mapper)
        {
            _livroService = livroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroViewModel>>> Get(string? search)
        {
            var livroEntities = await _livroService.GetAllAsync(search);

            return Ok(_mapper.Map<IEnumerable<LivroViewModel>>(livroEntities));
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<LivroViewModel>> Get(int id)
        {
            var livroEntity = await _livroService.GetByIdAsync(id);

            return Ok(_mapper.Map<LivroViewModel>(livroEntity));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(LivroViewModel livroViewModel)
        {
            var livroEntity = _mapper.Map<LivroEntity>(livroViewModel);

            var id = await _livroService.AddAsync(livroEntity);

            return Ok(id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(LivroViewModel livroViewModel)
        {
            var livroNaoEncontrado = await _livroService.GetByIdAsync(livroViewModel.Id) is not null;

            if (livroNaoEncontrado)
            {
                return NotFound();
            }

            var livroEntity = _mapper.Map<LivroEntity>(livroViewModel);

            await _livroService.EditAsync(livroEntity);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var livroEntity = await _livroService.GetByIdAsync(id);

            if (livroEntity is null)
            {
                return NotFound();
            }

            await _livroService.EditAsync(livroEntity);

            return Ok();
        }
    }
}
