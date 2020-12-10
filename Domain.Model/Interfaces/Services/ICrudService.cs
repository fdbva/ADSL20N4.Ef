using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Services
{
    public interface ICrudService<TEntity> : ICrudRepository<TEntity>
        where TEntity : BaseEntity
    {
    }
}
