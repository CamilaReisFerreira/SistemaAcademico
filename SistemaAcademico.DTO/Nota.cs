using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DTO
{
    public class Nota
    {
        public int Codigo { get; set; }

        public int Id_Registro_Academico { get; set; }

        public int Id_Disciplina { get; set; }

        public decimal Nota1 { get; set; }

        public decimal Nota2 { get; set; }

        public decimal Nota3 { get; set; }

        public decimal Media { get; set; }

        public RegistroAcademico Registro_Academico { get; set; }

        public Disciplina Disciplina { get; set; }
    }
}
