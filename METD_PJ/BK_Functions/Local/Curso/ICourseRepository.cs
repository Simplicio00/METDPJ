using BK_Functions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK_Functions.Local.Curso
{
    public interface ICourseRepository
    {
        List<CourseModel> Get();

    }
}
