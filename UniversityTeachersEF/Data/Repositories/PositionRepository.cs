using UniversityTeachersEF.Data.Entities;
using UniversityTeachersEF.Interfaces.Repositories;

namespace UniversityTeachersEF.Data.Repositories;

public class PositionRepository : GenericRepository<Position>, IPositionRepository
{
    public PositionRepository(UniversityTeachersDbContext dbContext) : base(dbContext)
    {
    }
}