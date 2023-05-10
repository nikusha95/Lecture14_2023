using ApiWithDatabase.Models;
using ApiWithDatabase.Repository;
using ApiWithDatabase.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiWithDatabase.Controllers;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly IGenericRepository<Student> _studentRepository;
    private readonly IGenericRepository<Subject> _subjectRepository;
    private readonly IGenericRepository<StudentSubject> _studentSubjectRepository;

    public StudentController(IGenericRepository<Student> studentRepository,
        IGenericRepository<Subject> subjectRepository, IGenericRepository<StudentSubject> studentSubjectRepository)
    {
        _studentRepository = studentRepository;
        _subjectRepository = subjectRepository;
        _studentSubjectRepository = studentSubjectRepository;
    }

    /// <summary>
    /// add subject to specific student
    /// </summary>
    /// <param name="studentId">student identification number</param>
    /// <param name="subject">subject</param>
    /// <returns></returns>
    [HttpPost("add-subject/{studentId}")]
    public async Task<IActionResult> AddSubject([FromRoute] int studentId, [FromBody] SubjectModel subject)
    {
        var student = await _studentRepository.GetByIdAsync(studentId);
        if (student != null)
        {
            var subjectItem = (await _subjectRepository.GetAllAsync(x => x.Name == subject.Name))
                ?.FirstOrDefault();

            if (subjectItem != null)
            {
                await _studentSubjectRepository.AddAsync(new StudentSubject
                {
                    Student = student,
                    Subject = subjectItem,
                    Point = 0
                });
                await _studentSubjectRepository.SaveAsync();

                return Ok("subject added");
            }

            await _studentSubjectRepository.AddAsync(new StudentSubject
            {
                Student = student,
                Subject = new Subject
                {
                    LowerBound = subject.LowerBound,
                    Name = subject.Name
                },
                Point = 0
            });
            await _studentSubjectRepository.SaveAsync();
            return Ok("subject added");
        }

        return BadRequest("student not found");
    }

    /// <summary>
    /// add student
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post(StudentModel student)
    {
        await _studentRepository.AddAsync(new Student
        {
            FirstName = student.FirstName,
            LastName = student.LastName,
            PersonalId = student.PersonalId,
            StartYear = student.StartYear
        });
        await _studentRepository.SaveAsync();

        return Ok("student added");
    }

    /// <summary>
    /// delete student
    /// </summary>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        _studentRepository.Delete(id);
        await _studentRepository.SaveAsync();

        return Ok("student added");
    }

    /// <summary>
    /// get student with his/hers subject
    /// </summary>
    /// <param name="studentId">student id</param>
    /// <returns></returns>
    [HttpGet("/subject-list/{studentId}")]
    public async Task<IActionResult> GetStudentBySubject(int studentId)
    {
      var data= await  _studentSubjectRepository
          .GetAllAsync(x => x.StudentId == studentId, 
          x => x.Student, x=>x.Subject);


      return Ok(data);
    }
}