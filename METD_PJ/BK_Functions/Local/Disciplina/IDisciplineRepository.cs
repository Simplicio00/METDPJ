using BK_Functions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK_Functions.Local.Disciplina
{
    public interface IDisciplineRepository
    {
        List<DisciplineModel> Get();
        void PostDisciplineIntoCourse(int disciplinaid, int cursoid);
        void DeleteDisciplineFromCourse(int disciplinaid, int cursoid);
    }
}
