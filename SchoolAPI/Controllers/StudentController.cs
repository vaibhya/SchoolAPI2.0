using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.ModelDTO;
using SchoolAPI.Service;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("School")]

    public class StudentController : Controller
    {
        private IStudentService _service;
        public StudentController(IStudentService service)
        {
            _service = service;

        }

        [HttpGet]
        [Route("GetStudents")]
        public IActionResult GetAllStudents(string? firstName, string? lastName, string? email, int? page = 1, int? limit = 10)
        {
            var students = _service.GetAllStudents(firstName, lastName, email, page, limit);
            return Ok(students);
        }

        [HttpGet]
        [Route("GetStudent/{id}")]
        public IActionResult GetStudentById(int id)
        {
            return Ok(_service.GetStudentById(id));
        }

        [HttpPost]
        [Route("PostStudent")]
        public IActionResult CreateStudent(StudentCreateDTO studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = _service.AddStudent(studentDto);
            return Ok(student);
        }

        [HttpPut]
        [Route("UpdateStudent")]
        public IActionResult UpdateStudent(StudentUpdateDTO studentDto)
        {
            return Ok(_service.UpdateStudent(studentDto));
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var response = _service.DeleteStudent(id);
            if (response == 0)
            {
                return NotFound();
            }
            return Ok("Student deleted successfully.");
        }
    }
}
