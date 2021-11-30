using Schools.Data.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class GradeDTOAvecStudents
    {
        public GradeDTOAvecStudents()
        {
            Students = new HashSet<StudentDTOOut>();
        }

        public string GradeName { get; set; }

        public virtual ICollection<StudentDTOOut> Students { get; set; }
    }
}
