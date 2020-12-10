using System.Threading.Tasks;
using AutoMapper;
using Domain.Model.Interfaces.Services;
using Domain.Model.Models;
using Domain.Model.UoW;
using Microsoft.AspNetCore.Mvc;
using WebApi.RequestContracts;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : CrudController<LivroRequest, LivroEntity>
    {
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LivroController(
            ILivroService livroService,
            IMapper mapper,
            IUnitOfWork unitOfWork) : 
            base(
                livroService,
                mapper, 
                unitOfWork)
        {
            _livroService = livroService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("LivroAutorCreate")]
        public async Task<ActionResult<int>> Post([FromBody] LivroAutorCreateRequest livroAutorCreateRequest)
        {
            var livroAutorCreateModel = _mapper.Map<LivroAutorCreateModel>(livroAutorCreateRequest);
            
            _unitOfWork.BeginTransaction();

            var id = await _livroService.AddAsync(livroAutorCreateModel);

            await _unitOfWork.CommitAsync();

            return Ok(id);
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
