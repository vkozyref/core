using CoreApp.DataAccess.Persistance;
using CoreApp.DataAccess.Transaction;
using System.Threading.Tasks;

namespace CoreApp.DataAccess.UnitOfWork
{
    internal class UniversityUnitOfWork : IUniversityUnitOfWork
    {
        private readonly UniversityContext _context;

        public UniversityUnitOfWork(UniversityContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<ITransactionAdapter> CreateTransaction()
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            return new TransactionAdapter(transaction);
        }
    }
}
