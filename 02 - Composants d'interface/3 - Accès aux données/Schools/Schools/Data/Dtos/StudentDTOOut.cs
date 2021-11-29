using Schools.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class StudentDTOOut
    {
        public StudentDTOOut()
        {
        }

        public string Name { get; set; }
        public int GradeId { get; set; }

        public virtual GradeDTOOut Grade { get; set; }
    }
}
