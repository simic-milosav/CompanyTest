using CompanyTest.Contracts.Repositories;

namespace CompanyTest.Contracts.UnitOfWork;
public interface IUnitOfWork : IDisposable
{
    IBaseRepository<T> GetRepository<T>() where T : class;
    Task SaveChangesAsync();
}
