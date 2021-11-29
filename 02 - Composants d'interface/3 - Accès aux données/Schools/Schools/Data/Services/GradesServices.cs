using Schools.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schools.Data.Services
{
    public class GradesServices
    {

        private readonly schoolsContext _context;

        public GradesServices(schoolsContext context)
        {
            _context = context;
        }

        public void AddGrade(Grade obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Grades.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteGrade(Grade obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.Grades.Remove(obj);
            _context.SaveChanges();
        }

        public IEnumerable<Grade> GetAllGrade()
        {
            return _context.Grades.ToList();
        }

        public Grade GetGradeById(int id)
        {
            return _context.Grades.FirstOrDefault(obj => obj.GradeId == id);
        }

        public void UpdateGrade(Grade obj)
        {
            _context.SaveChanges();
        }


    }
}
