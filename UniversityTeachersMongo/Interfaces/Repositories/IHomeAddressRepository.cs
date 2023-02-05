using UniversityTeachersMongo.Data.Entities;

namespace UniversityTeachersMongo.Interfaces.Repositories;

public interface IHomeAddressRepository
{
    Task<IEnumerable<HomeAddress>> GetAllAsync();

    Task<HomeAddress> GetByIdAsync(int id);
}