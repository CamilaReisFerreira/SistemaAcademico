using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DTO
{
    public class RegistroDisciplina
    {
        public int Codigo { get; set; }

        public int Id_Registro_Academico { get; set; }

        public int Id_Disciplina { get; set; }

        public RegistroAcademico Registro_Academico { get; set; }

        public Disciplina Disciplina { get; set; }
    }
}
