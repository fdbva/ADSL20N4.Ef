using System.Collections.Generic;
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
    public abstract class CrudController<TRequest, TEntity> : ControllerBase
        where TRequest : BaseRequest
        where TEntity : BaseEntity
    {
        private readonly ICrudService<TEntity> _crudService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        protected CrudController(
            ICrudService<TEntity> crudService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _crudService = crudService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{search?}")]
        public async Task<ActionResult<IEnumerable<TRequest>>> Get(string? search)
        {
            var autorEntities = await _crudService.GetAllAsync(search);

            var autorViewModels = _mapper.Map<IEnumerable<TRequest>>(autorEntities);

            return Ok(autorViewModels);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<TRequest>> Get([FromRoute] int id)
        {
            var autorEntity = await _crudService.GetByIdAsync(id);

            return Ok(_mapper.Map<TRequest>(autorEntity));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] TRequest autorRequest)
        {
            var autorEntity = _mapper.Map<TEntity>(autorRequest);

            _unitOfWork.BeginTransaction();

            var id = await _crudService.AddAsync(autorEntity);

            await _unitOfWork.CommitAsync();

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TRequest autorRequest)
        {
            if (id != autorRequest.Id)
            {
                return BadRequest();
            }

            var autor = await _crudService.GetByIdAsync(id);

            if (autor is null)
            {
                return NotFound();
            }

            var autorEntity = _mapper.Map<TEntity>(autorRequest);

            _unitOfWork.BeginTransaction();

            await _crudService.EditAsync(autorEntity);

            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var autorEntity = await _crudService.GetByIdAsync(id);

            if (autorEntity is null)
            {
                return NotFound();
            }

            _unitOfWork.BeginTransaction();

            await _crudService.RemoveAsync(autorEntity);

            await _unitOfWork.CommitAsync();

            return Ok();
        }
    }
}
