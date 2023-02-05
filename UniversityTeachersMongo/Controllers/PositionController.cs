using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniversityTeachersMongo.Data.Entities;
using UniversityTeachersMongo.DTOs;
using UniversityTeachersMongo.Interfaces.Repositories;

namespace UniversityTeachersMongo.Controllers;

[ApiController]
[Route("[controller]")]
public class PositionController : ControllerBase
{
    private readonly IPositionRepository _teacherRepository;
    private readonly IMapper _mapper;
    
    public PositionController(IPositionRepository teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<PositionResponse>>> Get()
    {
        try
        {
            var entities = await _teacherRepository.GetAllAsync();
            var results = entities.Select(_mapper.Map<Position, PositionResponse>);
            return Ok(results);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
        }
    }
}