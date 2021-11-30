using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TablesRelations.Data.Models;

namespace TablesRelations.Data.Services
{
    public class StudentService
    {

        private readonly schoolsContext _context;

        public StudentService(schoolsContext context)
        {
            _context = context;
        }

        public void AddStudent(Student obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Students.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteStudent(Student obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Students.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _context.Students.FirstOrDefault(obj => obj.StudentId == id);
        }

        public void UpdateStudent(Student obj)
        {
            _context.SaveChanges();
        }


    }
}
