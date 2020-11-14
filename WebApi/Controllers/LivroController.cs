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

        [HttpGet("{search?}")]
        public async Task<ActionResult<IEnumerable<LivroViewModel>>> Get(string? search)
        {
            var livroEntities = await _livroService.GetAllAsync(search);

            var livroViewModels = _mapper.Map<IEnumerable<LivroViewModel>>(livroEntities);

            return Ok(livroViewModels);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<LivroViewModel>> Get([FromRoute] int id)
        {
            var livroEntity = await _livroService.GetByIdAsync(id);

            return Ok(_mapper.Map<LivroViewModel>(livroEntity));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] LivroViewModel livroViewModel)
        {
            var livroEntity = _mapper.Map<LivroEntity>(livroViewModel);

            var id = await _livroService.AddAsync(livroEntity);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, LivroViewModel livroViewModel)
        {
            if (id != livroViewModel.Id)
            {
                return BadRequest();
            }

            var livro = await _livroService.GetByIdAsync(id);

            if (livro is null)
            {
                return NotFound();
            }

            var livroEntity = _mapper.Map<LivroEntity>(livroViewModel);

            await _livroService.EditAsync(livroEntity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var livroEntity = await _livroService.GetByIdAsync(id);

            if (livroEntity is null)
            {
                return NotFound();
            }

            await _livroService.RemoveAsync(livroEntity);

            return Ok();
        }

        [HttpGet("IsIsbnValid/{isbn}/{id?}")]
        public async Task<IActionResult> IsIsbnValid(string isbn, int? id)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return BadRequest("Isbn inválido");

            return Ok(await _livroService.IsIsbnValidAsync(isbn, id));
        }
    }
}
