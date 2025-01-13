using CompanyTest.Contracts.Repositories;
using CompanyTest.Contracts.UnitOfWork;
using CompanyTest.Infrastructure.Database;
using CompanyTest.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Infrastructure.UnitOfWork;
public class UnitOfWork(
    ApplicationDbContext context,
    ILoggerFactory loggerFactory) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;
    private Dictionary<Type, object> _repositories = [];
    private readonly ILoggerFactory _loggerFactory = loggerFactory;

    public IBaseRepository<T> GetRepository<T>() where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (IBaseRepository<T>)_repositories[typeof(T)];
        }

        var repository = new BaseRepository<T>(_context, new Logger<BaseRepository<T>>(_loggerFactory));
        _repositories.Add(typeof(T), repository);

        return repository;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
    public void Dispose() => _context.Dispose();
}
