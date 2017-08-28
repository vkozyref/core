using CoreApp.DataAccess.Transaction;
using System.Threading.Tasks;

namespace CoreApp.DataAccess.UnitOfWork
{
    public interface IUniversityUnitOfWork
    {
        Task CommitAsync();
        Task<ITransactionAdapter> CreateTransaction();
    }
}
