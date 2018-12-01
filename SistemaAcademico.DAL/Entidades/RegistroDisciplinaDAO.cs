using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Entidades
{
    [Table("RegistroDisciplina")]
    public class RegistroDisciplinaDAO
    {
        [Key]
        public int Codigo { get; set; }

        public int Id_Registro_Academico { get; set; }

        public int Id_Disciplina { get; set; }
    }
}
