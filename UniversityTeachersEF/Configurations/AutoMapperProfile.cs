using AutoMapper;
using UniversityTeachersEF.Data.Entities;
using UniversityTeachersEF.DTOs;

namespace UniversityTeachersEF.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Discipline, DisciplineResponse>();

        CreateMap<HomeAddress, HomeAddressResponse>();

        CreateMap<Position, PositionResponse>();

        CreateMap<Street, StreetResponse>();
        
        CreateMap<Teacher, TeacherResponse>();

        CreateMap<Teacher, TeacherFullResponse>()
            .ForMember(response => response.PositionName, expression => expression
                .MapFrom(teacher => teacher.Position.Name))
            .ForMember(response => response.WorkPlaceName, expression => expression
                .MapFrom(teacher => teacher.WorkPlace.PlaceName));

        CreateMap<TeachersDiscipline, TeachersDisciplinesResponse>()
            .ForMember(response => response.DisciplineName, expression => expression
                .MapFrom(teachersDiscipline => teachersDiscipline.Discipline.Name));

        CreateMap<WorkPlace, WorkPlaceResponse>();
    }
}