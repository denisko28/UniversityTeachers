using UniversityTeachersEF.Data.Entities;

namespace UniversityTeachersEF.Interfaces.Repositories;

public interface IStreetRepository
{
    Task<IEnumerable<Street>> GetAllAsync();
}