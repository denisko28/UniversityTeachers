using UniversityTeachersEF.Data.Entities;

namespace UniversityTeachersEF.Interfaces.Repositories;

public interface IHomeAddressRepository
{
    Task<IEnumerable<HomeAddress>> GetAllAsync();
}