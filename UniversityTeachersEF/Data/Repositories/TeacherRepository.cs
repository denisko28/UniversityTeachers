using Microsoft.EntityFrameworkCore;
using UniversityTeachersEF.Data.Entities;
using UniversityTeachersEF.Data.Exceptions;
using UniversityTeachersEF.Interfaces.Repositories;

namespace UniversityTeachersEF.Data.Repositories;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(UniversityTeachersDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Teacher> GetByIdFullEntityAsync(int id)
    {
        return await _table
                   .Include(teacher => teacher.HomeAddress)
                   .ThenInclude(address => address.Street)
                   .Include(teacher => teacher.WorkPlace)
                   .Include(teacher => teacher.Position)
                   .SingleOrDefaultAsync(teacher => teacher.Id == id)
               ?? throw new EntityNotFoundException(nameof(Teacher), id);
    }

    public async Task<IEnumerable<TeachersDiscipline>> GetTeachersDisciplines(int teacherId)
    {
        var teacher = await _table
                          .Include(teacher => teacher.TeachersDisciplines)
                          .ThenInclude(teacherDiscipline => teacherDiscipline.Discipline)
                          .SingleOrDefaultAsync(teacher => teacher.Id == teacherId)
                      ?? throw new EntityNotFoundException(nameof(Teacher), teacherId);

        return teacher.TeachersDisciplines;
    }

    public async Task<TeachersCharacteristic> GetCharacteristic(int teacherId)
    {
        var teacher = await _table
                          .Include(teacher => teacher.TeachersCharacteristic)
                          .SingleOrDefaultAsync(teacher => teacher.Id == teacherId)
                      ?? throw new EntityNotFoundException(nameof(Teacher), teacherId);
        return teacher.TeachersCharacteristic;
    }
}