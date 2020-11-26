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

        [HttpGet("{search?}")]
        public async Task<ActionResult<IEnumerable<AutorRequest>>> Get(string? search)
        {
            var autorEntities = await _autorService.GetAllAsync(search);

            var autorViewModels = _mapper.Map<IEnumerable<AutorRequest>>(autorEntities);

            return Ok(autorViewModels);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<AutorRequest>> Get([FromRoute]int id)
        {
            var autorEntity = await _autorService.GetByIdAsync(id);

            return Ok(_mapper.Map<AutorRequest>(autorEntity));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody]AutorRequest autorRequest)
        {
            var autorEntity = _mapper.Map<AutorEntity>(autorRequest);

            var id = await _autorService.AddAsync(autorEntity);

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, AutorRequest autorRequest)
        {
            if (id != autorRequest.Id)
            {
                return BadRequest();
            }

            var autor = await _autorService.GetByIdAsync(id);

            if (autor is null)
            {
                return NotFound();
            }

            var autorEntity = _mapper.Map<AutorEntity>(autorRequest);

            await _autorService.EditAsync(autorEntity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var autorEntity = await _autorService.GetByIdAsync(id);

            if (autorEntity is null)
            {
                return NotFound();
            }

            await _autorService.RemoveAsync(autorEntity);

            return Ok();
        }
    }
}
