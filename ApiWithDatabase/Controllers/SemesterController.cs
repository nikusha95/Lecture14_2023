using ApiWithDatabase.Models;
using ApiWithDatabase.Repository;
using ApiWithDatabase.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;

namespace ApiWithDatabase.Controllers;

[ApiController]
[Route("api/semester")]
public class SemesterController : ControllerBase
{
    private readonly IGenericRepository<Semester> _repository;

    public SemesterController(IGenericRepository<Semester> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// get semester
    /// </summary>
    /// <param name="id">identification number of semester</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(SemesterModel), 200)]
    public async Task<IActionResult> Get(int id)
    {
        var data = await _repository.GetByIdAsync(id);

        if (data == null)
        {
            return NotFound();
        }

        return Ok(new SemesterModel
        {
            Name = data.Name,
            AvailableGpa = data.AvailableGpa,
            StartDate = data.StartDate,
            EndDate = data.EndDate
        });
    }

    /// <summary>
    /// adds semester
    /// </summary>
    /// <param name="semester">semester object</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> AddSemester(SemesterModel semester)
    {
        Semester s = new Semester
        {
            Name = semester.Name,
            AvailableGpa = semester.AvailableGpa,
            StartDate = semester.StartDate,
            EndDate = semester.EndDate
        };
        await _repository.AddAsync(s);
        await _repository.SaveAsync();

        return Created($"/api/semester/{s.Id}", s);
    }
}