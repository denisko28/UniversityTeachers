using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityTeachersADO.Data.Entities;
using UniversityTeachersADO.Data.Exceptions;
using UniversityTeachersADO.DTOs;
using UniversityTeachersADO.Interfaces.Repositories;

namespace UniversityTeachersADO.Controllers;

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
            var results = (TeacherFullResponse) _mapper.Map<dynamic, TeacherFullResponse>(entity);
            results.HomeFullAddress = entity.HomeAddressStreet + ", буд. " + entity.HomeAddressBuilding +
                                      (entity.HomeAddressFlatNum != 0 ? ", кв. " + entity.HomeAddressFlatNum : "");
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
                entities.Select(_mapper.Map<dynamic, TeachersDisciplinesResponse>);
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