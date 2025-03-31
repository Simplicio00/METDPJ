using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK_Functions.Models
{
    public class CourseModel
    {
        public int Id { get; set; } 
        public required string Name { get; set; }

        public required List<DisciplineModel> Disciplines { get; set; }
    }
}
