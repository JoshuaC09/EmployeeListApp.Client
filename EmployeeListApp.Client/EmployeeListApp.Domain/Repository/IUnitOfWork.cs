namespace EmployeeListApp.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }
        int SaveChanges();
    }
}
