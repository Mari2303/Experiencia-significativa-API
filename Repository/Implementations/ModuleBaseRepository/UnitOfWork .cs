using Entity.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Interfaces.IModuleBaseRepository;

namespace Repository.Implementations.ModuleBaseRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }


        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
        }



    }
}