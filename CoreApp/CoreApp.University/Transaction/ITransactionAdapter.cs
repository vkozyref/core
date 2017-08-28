using System;

namespace CoreApp.DataAccess.Transaction
{
    public interface ITransactionAdapter : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
