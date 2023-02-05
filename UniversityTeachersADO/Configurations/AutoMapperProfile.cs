using AutoMapper;
using UniversityTeachersADO.Data.Entities;
using UniversityTeachersADO.DTOs;

namespace UniversityTeachersADO.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Teacher, TeacherResponse>();
        
        CreateMap<Discipline, DisciplineResponse>();

        CreateMap<HomeAddress, HomeAddressResponse>();

        CreateMap<Position, PositionResponse>();

        CreateMap<Street, StreetResponse>();
        
        CreateMap<Teacher, TeacherResponse>();

        CreateMap<WorkPlace, WorkPlaceResponse>();
    }
}