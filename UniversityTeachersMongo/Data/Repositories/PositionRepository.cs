using UniversityTeachersMongo.Data.Entities;
using UniversityTeachersMongo.Interfaces.Repositories;

namespace UniversityTeachersMongo.Data.Repositories;

public class PositionRepository : GenericRepository<Position>, IPositionRepository
{
    public PositionRepository(MongoDbContext dbContext) : base(dbContext)
    {
    }
}