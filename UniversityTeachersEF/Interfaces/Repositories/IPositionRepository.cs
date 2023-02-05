using UniversityTeachersEF.Data.Entities;

namespace UniversityTeachersEF.Interfaces.Repositories;

public interface IPositionRepository
{
    Task<IEnumerable<Position>> GetAllAsync();
}