using UniversityTeachersMongo.Data.Entities;
using UniversityTeachersMongo.Interfaces.Repositories;

namespace UniversityTeachersMongo.Data.Repositories;

public class StreetRepository : GenericRepository<Street>, IStreetRepository
{
    public StreetRepository(MongoDbContext dbContext) : base(dbContext)
    {
    }
}