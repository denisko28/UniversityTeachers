using Microsoft.EntityFrameworkCore;
using UniversityTeachersEF.Data.Entities;
using UniversityTeachersEF.Interfaces.Repositories;

namespace UniversityTeachersEF.Data.Repositories;

public class WorkPlaceRepository : GenericRepository<WorkPlace>, IWorkPlaceRepository
{
    public WorkPlaceRepository(UniversityTeachersDbContext dbContext) : base(dbContext)
    {
    }
}