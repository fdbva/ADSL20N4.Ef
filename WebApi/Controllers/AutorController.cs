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
    public class AutorController : CrudController<AutorRequest, AutorEntity>
    {
        public AutorController(
            IAutorService autorService,
            IMapper mapper,
            IUnitOfWork unitOfWork) : 
            base(
                autorService,
                mapper,
                unitOfWork)
        {
        }
    }
}
