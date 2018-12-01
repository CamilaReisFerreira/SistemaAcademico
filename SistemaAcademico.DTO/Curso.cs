using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DTO
{
    public class Curso
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime Data_Inicio { get; set; }

        public decimal Carga_Horaria { get; set; }
    }
}
