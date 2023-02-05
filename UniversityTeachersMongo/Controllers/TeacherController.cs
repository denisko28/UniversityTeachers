using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityTeachersEF.Data.Exceptions;
using UniversityTeachersMongo.Data.Entities;
using UniversityTeachersMongo.DTOs;
using UniversityTeachersMongo.Interfaces.Repositories;

namespace UniversityTeachersMongo.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IHomeAddressRepository _homeAddressRepository;
    private readonly IStreetRepository _streetRepository;
    private readonly IWorkPlaceRepository _workPlaceRepository;
    private readonly IPositionRepository _positionRepository;
    private readonly IDisciplineRepository _disciplineRepository;
    private readonly IMapper _mapper;

    public TeacherController(ITeacherRepository teacherRepository, IHomeAddressRepository homeAddressRepository, 
        IStreetRepository streetRepository, IWorkPlaceRepository workPlaceRepository, 
        IPositionRepository positionRepository, IDisciplineRepository disciplineRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _homeAddressRepository = homeAddressRepository;
        _streetRepository = streetRepository;
        _workPlaceRepository = workPlaceRepository;
        _positionRepository = positionRepository;
        _disciplineRepository = disciplineRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<TeacherResponse>>> Get()
    {
        try
        {
            var entities = await _teacherRepository.GetAllAsync();
            var results = entities.Select(_mapper.Map<Teacher, TeacherResponse>);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TeacherResponse>> GetById(int id)
    {
        try
        {
            var entity = await _teacherRepository.GetByIdAsync(id);
            var results = _mapper.Map<Teacher, TeacherResponse>(entity);
            return Ok(results);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new {e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpGet("full/{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<TeacherFullResponse>> GetByIdFullEntityAsync(int id)
    {
        try
        {
            var entity = await _teacherRepository.GetByIdAsync(id);
            var teachersHomeAddress = await _homeAddressRepository.GetByIdAsync(entity.HomeAddressId);
            var teachersHomeAddressStreet = await _streetRepository.GetByIdAsync(teachersHomeAddress.StreetId);
            var teachersWorkPlace = await _workPlaceRepository.GetByIdAsync(entity.WorkPlaceId);
            var teachersPosition = await _positionRepository.GetByIdAsync(entity.PositionId);
            var teachersCharacteristic = await _teacherRepository.GetCharacteristic(id);
            
            var result = _mapper.Map<Teacher, TeacherFullResponse>(entity);
            result.HomeFullAddress = teachersHomeAddressStreet.StreetName + ", буд. " + teachersHomeAddress.Building +
                                      (teachersHomeAddress.FlatNum != null ? ", кв. " + teachersHomeAddress.FlatNum : "");
            result.WorkPlaceName = teachersWorkPlace.PlaceName;
            result.PositionName = teachersPosition.Name;
            result.Characteristic = teachersCharacteristic.Characteristic;
            return Ok(result);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new {e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }

    [HttpGet("disciplines/{teacherId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<TeachersDisciplinesResponse>>> GetTeachersDisciplines(int teacherId)
    {
        try
        {
            var entities = await _teacherRepository.GetTeachersDisciplines(teacherId);

            var results = new List<TeachersDisciplinesResponse>();
            foreach (var entity in entities)
            {
                var result = _mapper.Map<TeachersDiscipline, TeachersDisciplinesResponse>(entity);
                var discipline = await _disciplineRepository.GetByIdAsync(entity.DisciplineId);
                result.DisciplineName = discipline.Name;
                results.Add(result);
            }
            
            return Ok(results);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new {e.Message});
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new {e.Message});
        }
    }
}