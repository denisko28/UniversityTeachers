using AutoMapper;
using UniversityTeachersMongo.Data.Entities;
using UniversityTeachersMongo.DTOs;

namespace UniversityTeachersMongo.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Discipline, DisciplineResponse>();

        CreateMap<HomeAddress, HomeAddressResponse>();

        CreateMap<Position, PositionResponse>();

        CreateMap<Street, StreetResponse>();
        
        CreateMap<Teacher, TeacherResponse>();

        CreateMap<Teacher, TeacherFullResponse>();

        CreateMap<TeachersDiscipline, TeachersDisciplinesResponse>();

        CreateMap<WorkPlace, WorkPlaceResponse>();
    }
}