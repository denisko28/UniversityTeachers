using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityTeachersADO.Data.Entities;
using UniversityTeachersADO.DTOs;
using UniversityTeachersADO.Interfaces.Repositories;

namespace UniversityTeachersADO.Controllers;

[ApiController]
[Route("[controller]")]
public class DisciplineController : ControllerBase
{
    private readonly IDisciplineRepository _teacherRepository;
    private readonly IMapper _mapper;
    
    public DisciplineController(IDisciplineRepository teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<DisciplineResponse>>> Get()
    {
        try
        {
            var entities = await _teacherRepository.GetAllAsync();
            var results = entities.Select(_mapper.Map<Discipline, DisciplineResponse>);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}