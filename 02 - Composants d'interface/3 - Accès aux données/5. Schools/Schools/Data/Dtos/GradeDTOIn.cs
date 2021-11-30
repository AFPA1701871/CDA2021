using System;
using System.Collections.Generic;

#nullable disable

namespace Schools.Data.Dtos
{
    public partial class GradeDTOIn
    {
        public GradeDTOIn()
        {
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }

    }
}
