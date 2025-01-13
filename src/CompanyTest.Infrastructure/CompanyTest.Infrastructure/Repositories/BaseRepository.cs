using CompanyTest.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CompanyTest.Infrastructure.Repositories;
internal sealed class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DbSet<T> _set;
    protected readonly ILogger<BaseRepository<T>> _logger;

    public BaseRepository(
        DbContext context,
        ILogger<BaseRepository<T>> logger)
    {
        _set = context.Set<T>();
        _logger = logger;
    }

    public async Task<bool> CreateAsync(T entity)
    {
        try
        {
            await _set.AddAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding entity");
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var entity = await _set.FindAsync(id);
            if (entity != null)
            {
                _set.Remove(entity);
                return true;
            }
            else
            {
                _logger.LogWarning("Entity with id {Id} not found for deletion", id);
                return false;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error deleting entity with id {Id}", id);
            return false;
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
        => await _set.ToListAsync();

    public async Task<T> GetByIdAsync(Guid id)
        => await _set.FindAsync(id);

    public async Task<bool> UpdateAsync(T entity)
    {
        try
        {
            _set.Update(entity);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while updating entity");
            return false;
        }
    }
}
