using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> StudentsList = new List<Student>();

        [HttpGet("next-id")]
        public IActionResult GetNextId()
        {
            int nextNum = StudentsList.Count + 1;
            string studentId = "STU" + nextNum.ToString("D3");
            return Ok(new { studentId });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(StudentsList);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Student student)
        {
            if (string.IsNullOrEmpty(student.StudentId))
            {
                int nextNum = StudentsList.Count + 1;
                student.StudentId = "STU" + nextNum.ToString("D3");
            }
            StudentsList.Add(student);
            return Ok(new { success = true, studentId = student.StudentId });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var student = StudentsList.FirstOrDefault(s => s.Username == model.Username && s.Password == model.Password);
            if (student != null)
            {
                return Ok(new { success = true });
            }
            return Unauthorized(new { success = false });
        }
    }
}
