using UniversityTeachersEF.Data.Entities;
using UniversityTeachersEF.Interfaces.Repositories;

namespace UniversityTeachersEF.Data.Repositories;

public class StreetRepository : GenericRepository<Street>, IStreetRepository
{
    public StreetRepository(UniversityTeachersDbContext dbContext) : base(dbContext)
    {
    }
}