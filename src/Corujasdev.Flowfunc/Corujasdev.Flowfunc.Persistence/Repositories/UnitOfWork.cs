using Corujasdev.Flowfunc.Application.Repositories;
using Corujasdev.Flowfunc.Persistence.Context;

namespace Corujasdev.Flowfunc.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public Task Save(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
