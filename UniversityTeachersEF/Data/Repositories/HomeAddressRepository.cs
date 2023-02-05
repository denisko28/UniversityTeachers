using UniversityTeachersEF.Data.Entities;
using UniversityTeachersEF.Interfaces.Repositories;

namespace UniversityTeachersEF.Data.Repositories;

public class HomeAddressRepository : GenericRepository<HomeAddress>, IHomeAddressRepository
{
    public HomeAddressRepository(UniversityTeachersDbContext dbContext) : base(dbContext)
    {
    }
}