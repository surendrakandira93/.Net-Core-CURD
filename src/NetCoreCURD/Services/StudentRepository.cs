using System.Collections.Generic;
using System.Linq;
using NetCoreCURD.Models;

namespace NetCoreCURD.Services
{
    public interface IStudentRepository
    {
        IEnumerable<StudentModel> GetAll();

        StudentModel Get(int id);

        void Add(StudentModel newStudent);

        void Update(StudentModel newStudent);

        int Max();

        void Delete(int id);
    }

    public class StudentRepository : IStudentRepository
    {
        private static List<StudentModel> _students;

        public void Add(StudentModel newStudent)
        {
            _students.Add(newStudent);
        }

        public void Update(StudentModel newStudent)
        {
            var getStudent = _students.FirstOrDefault(r => r.Id == newStudent.Id);
            if (getStudent != null)
            {
                _students.Remove(getStudent);
                _students.Add(newStudent);
            }
        }

        public StudentModel Get(int id)
        {
            return _students.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<StudentModel> GetAll()
        {
            return _students;
        }

        public int Max()
        {
            return _students.Count()>0?_students.Max(x => x.Id):0;
        }

        public void Delete(int id)
        {
            var getStudent = _students.FirstOrDefault(r => r.Id == id);
            if (getStudent != null)
                _students.Remove(getStudent);
        }

        static StudentRepository()
        {
            _students = new List<StudentModel>
            {
                new StudentModel { Id = 1, Name="Surendra kandira" },
                new StudentModel { Id = 2, Name = "Ashok" },
                new StudentModel { Id = 3, Name = "Rakesh Singh" }
            };
        }
    }
}