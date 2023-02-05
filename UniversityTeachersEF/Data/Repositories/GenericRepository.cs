using Microsoft.EntityFrameworkCore;
using UniversityTeachersEF.Data.Exceptions;

namespace UniversityTeachersEF.Data.Repositories;

public class GenericRepository<TEntity> where TEntity : class
{
    protected readonly UniversityTeachersDbContext _dbContext;
    protected readonly DbSet<TEntity> _table;

    protected GenericRepository(UniversityTeachersDbContext dBContext)
    {
        _dbContext = dBContext;
        _table = _dbContext.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _table.ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _table.FindAsync(id)
               ?? throw new EntityNotFoundException(typeof(TEntity).Name, id);
    }
}