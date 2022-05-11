using DapperCRUD.Manager;
using DapperCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperCRUD.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       // StudentAccess studentAccess;
        StudentManager studentManager;
        public StudentController()
        {
           // studentAccess = new StudentAccess();
            studentManager = new StudentManager();
        }
        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> GetStudents()
        {
            List<Student> students = studentManager.GetStudents();
            return students;

        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student GetStudent(int id)
        {
            Student student = studentManager.GetStudent(id);
            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public Student InsertStudent([FromBody] Student student)
        {
            var AddStudent = studentManager.InsertStudent(student);
           return AddStudent;
        }


        [HttpPatch("{id}")]
        public int UpdateStudent(int id, [FromBody] Student student)
        {
            var AddStudent = studentManager.UpdateStudent(student);
            return AddStudent;
        }
        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public int DeleteStudent(int id)
        {
            
            var AddStudent = studentManager.DeleteStudent(id);
            return AddStudent;
        }
    }
}
