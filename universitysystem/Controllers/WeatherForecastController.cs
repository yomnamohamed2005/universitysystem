using Microsoft.AspNetCore.Mvc;
using universitysystem.Models;

namespace universitysystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 2022345, Name = "Ahmed Said" },
            new Student { Id = 2021389, Name = "Rasha Mohamed" },
            new Student { Id = 2020456, Name = "Yaser Mohsen" }
        };

       
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(students);
        }

     
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(student); 

        }


        [HttpPost]
        public IActionResult AddStudent([FromBody] Student newStudent)
        {
            if (students.Any(s => s.Id == newStudent.Id))
            {
                return NotFound("Student with this ID already exists.");
            }
            students.Add(newStudent);
            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudent); 
        }
       
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id,string NewName)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return BadRequest(new { Message = $"Student With id {id} Doesnt Exist" });
            }
            student.Name = NewName;
            return NoContent();
        }
            
            [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound(new { Message = $"Student With id {id} Doesnt Exist" });
            }
            students.Remove(student); 
            return NoContent();
        }

      
    }
}