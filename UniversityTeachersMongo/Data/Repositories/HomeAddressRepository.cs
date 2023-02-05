using MongoDB.Driver;
using UniversityTeachersEF.Data.Exceptions;
using UniversityTeachersMongo.Data.Entities;
using UniversityTeachersMongo.Interfaces.Repositories;

namespace UniversityTeachersMongo.Data.Repositories;

public class HomeAddressRepository : GenericRepository<HomeAddress>, IHomeAddressRepository
{
    public HomeAddressRepository(MongoDbContext dbContext) : base(dbContext)
    {
    }

    // public async Task<HomeAddress> GetByIdAsync(int id)
    // {
    //     return await Collection
    //                .Find(x => x.Id == id).FirstOrDefaultAsync()
    //            ?? throw new EntityNotFoundException(nameof(HomeAddress), id);
    // }
}