using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Models
{
    public partial class Course
    {
        public Course()
        {
            Studentscourses = new HashSet<Studentscourse>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Studentscourse> Studentscourses { get; set; }
    }
}
