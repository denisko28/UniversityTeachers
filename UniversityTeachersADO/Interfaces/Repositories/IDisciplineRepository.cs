using UniversityTeachersADO.Data.Entities;

namespace UniversityTeachersADO.Interfaces.Repositories;

public interface IDisciplineRepository
{
    Task<IEnumerable<Discipline>> GetAllAsync();
}