using UniversityTeachersADO.Data.Entities;

namespace UniversityTeachersADO.Interfaces.Repositories;

public interface IHomeAddressRepository
{
    Task<IEnumerable<HomeAddress>> GetAllAsync();
}