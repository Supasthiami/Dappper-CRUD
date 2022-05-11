using DapperCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUD.Access
{
    public interface IStudentAccess
    {
        public List<Student> GetStudents();
        public Student GetStudent(int id);

        public Student InsertStudent(Student student);
        public int UpdateStudent(Student student);

        public int DeleteStudent(int id);

    }
}
