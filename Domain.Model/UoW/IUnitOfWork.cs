using System.Threading.Tasks;

namespace Domain.Model.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task CommitAsync();
    }
}
