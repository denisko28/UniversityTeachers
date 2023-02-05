using UniversityTeachersMongo.Data.Entities;
using UniversityTeachersMongo.Interfaces.Repositories;

namespace UniversityTeachersMongo.Data.Repositories;

public class WorkPlaceRepository : GenericRepository<WorkPlace>, IWorkPlaceRepository
{
    public WorkPlaceRepository(MongoDbContext dbContext) : base(dbContext)
    {
    }
}