using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityTeachersEF.Data.Entities;
using UniversityTeachersEF.Data.Exceptions;
using UniversityTeachersEF.DTOs;
using UniversityTeachersEF.Interfaces.Repositories;

namespace UniversityTeachersEF.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IMapper _mapper;
    
    public TeacherController(ITeacherRepository teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
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
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
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
            return NotFound(new { e.Message });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
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
            var entity = await _teacherRepository.GetByIdFullEntityAsync(id);
            var teachersCharacteristic = await _teacherRepository.GetCharacteristic(id);
            var results = _mapper.Map<Teacher, TeacherFullResponse>(entity);
            results.HomeFullAddress = entity.HomeAddress.Street.StreetName + ", буд. " + entity.HomeAddress.Building +
                                      (entity.HomeAddress.FlatNum != null ? ", кв. " + entity.HomeAddress.FlatNum : "");
            results.Characteristic = teachersCharacteristic.Characteristic;
            return Ok(results);
        }
        catch (EntityNotFoundException e)
        {
            return NotFound(new { e.Message });
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
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
            var results = 
                entities.Select(_mapper.Map<TeachersDiscipline, TeachersDisciplinesResponse>);
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