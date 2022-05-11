using DapperCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using DapperCRUD.Access;

namespace DapperCRUD.Access
{
    public class StudentAccess : IStudentAccess
    {
        private string sqlConnectionString = @"Data Source = 'DESKTOP-OHFCIPU\SQLEXPRESS';initial catalog='DapperCRUD';Integrated Security=True";

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            using(var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<Student>("Select StudentID,Name,Marks from Student").ToList();
                connection.Close();
            }
            return students;
        }

        public Student GetStudent(int Id)
        {
            Student students = new Student();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                students = connection.Query<Student>("Select StudentID,Name,Marks from Student Where StudentID = @StudentID ",new { StudentID = Id }).SingleOrDefault();
                connection.Close();
            }
            return students;
        }

        public Student InsertStudent(Student student)
        {
            using(var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var addStudent= connection.Execute("Insert into Student (Name, Marks) values (@Name, @Marks)", new { Name = student.Name, Marks = student.Marks });
                connection.Close();
                return student;
            }
        }


        public int UpdateStudent(Student student)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var updateStudent = connection.Execute("Update Student set Name = @Name, Marks =  @Marks Where StudentID =@StudentID", new { Name = student.Name, Marks = student.Marks ,StudentID = student.StudentID});
                connection.Close();
                return updateStudent;
            }
        }


        public int DeleteStudent(int id)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var deleteStudent = connection.Execute("Delete from  Student Where StudentID=@StudentID", new { StudentID = id });
                connection.Close();
                return deleteStudent;
            }
        }

    }
}
