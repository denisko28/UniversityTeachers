using UniversityTeachersADO.Data.Entities;

namespace UniversityTeachersADO.Interfaces.Repositories;

public interface IWorkPlaceRepository
{
    Task<IEnumerable<WorkPlace>> GetAllAsync();
}