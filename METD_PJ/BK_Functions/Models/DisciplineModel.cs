using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BK_Functions.Models
{
    //"Algoritmos e Estruturas de Dados",
    //"Arquitetura de Computadores",
    //"Banco de Dados",
    //"Desenvolvimento de Software",
    //"Engenharia de Software",
    //"Redes de Computadores",
    //"Sistemas Operacionais",
    //"Programação Orientada a Objetos",
    //"Inteligência Artificial",
    //"Segurança da Informação",
    //"Matemática Discreta",
    //"Cálculo",
    //"Programação Web",
    //"Desenvolvimento Mobile",
    //"Gestão de Tecnologia da Informação"
    public class DisciplineModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public List<CourseModel>? Courses { get; set; }
    }
}
