using UniversityTeachersMongo.Data.Entities;
using UniversityTeachersMongo.Interfaces.Repositories;

namespace UniversityTeachersMongo.Data.Repositories;

public class DisciplineRepository : GenericRepository<Discipline>, IDisciplineRepository
{
    public DisciplineRepository(MongoDbContext dbContext) : base(dbContext)
    {
    }
}