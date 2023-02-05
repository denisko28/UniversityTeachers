using UniversityTeachersEF.Data.Entities;
using UniversityTeachersEF.Interfaces.Repositories;

namespace UniversityTeachersEF.Data.Repositories;

public class DisciplineRepository : GenericRepository<Discipline>, IDisciplineRepository
{
    public DisciplineRepository(UniversityTeachersDbContext dbContext) : base(dbContext)
    {
    }
}