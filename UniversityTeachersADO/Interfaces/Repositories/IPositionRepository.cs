using UniversityTeachersADO.Data.Entities;

namespace UniversityTeachersADO.Interfaces.Repositories;

public interface IPositionRepository
{
    Task<IEnumerable<Position>> GetAllAsync();
}