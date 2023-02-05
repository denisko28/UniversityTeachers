using MongoDB.Driver;
using UniversityTeachersEF.Data.Exceptions;

namespace UniversityTeachersMongo.Data.Repositories;

public class GenericRepository<TEntity> where TEntity : class
{
    protected readonly IMongoCollection<TEntity> Collection;
    protected readonly MongoDbContext DbContext;

    protected GenericRepository(MongoDbContext dBContext)
    {
        DbContext = dBContext;
        Collection = dBContext.Collection<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await Collection.Find(_ => true).ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id);
        return await Collection.Find(filter).FirstOrDefaultAsync() 
               ?? throw new EntityNotFoundException(typeof(TEntity).Name, id);;
    }
}