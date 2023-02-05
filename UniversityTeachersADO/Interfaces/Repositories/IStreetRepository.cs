using UniversityTeachersADO.Data.Entities;

namespace UniversityTeachersADO.Interfaces.Repositories;

public interface IStreetRepository
{
    Task<IEnumerable<Street>> GetAllAsync();
}