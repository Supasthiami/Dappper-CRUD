using DapperCRUD.Access;
using DapperCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUD.Manager
{
    public class StudentManager
    {
        IStudentAccess studentAccess;

        public StudentManager()
        {
            studentAccess = new StudentAccess();
        }
        public StudentManager(IStudentAccess _studentAccess)
        {
            studentAccess = _studentAccess;
        }


        public List<Student> GetStudents()
        {
            List<Student> students = studentAccess.GetStudents();
            return students;
        }

        public Student GetStudent(int id)
        {
            Student student = studentAccess.GetStudent(id);
            return student;
        }

        
        public Student InsertStudent(Student student)
        {
            var AddStudent = studentAccess.InsertStudent(student);
            return AddStudent;
        }

        public int UpdateStudent( Student student)
        {
            var AddStudent = studentAccess.UpdateStudent(student);
            return AddStudent;
        }
    
        public int DeleteStudent(int id)
        {
            var AddStudent = studentAccess.DeleteStudent(id);
            return AddStudent;
        }
    }
}
