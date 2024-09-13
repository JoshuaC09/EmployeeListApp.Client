using EmployeeListApp.DataAccess.Context;
using EmployeeListApp.Domain.Repository;

namespace EmployeeListApp.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(_context);
        }
        public IEmployeeRepository EmployeeRepository { get; }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}