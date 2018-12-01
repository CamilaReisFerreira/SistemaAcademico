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

        public int? FK_RD_RA { get; set; }

        public int? FK_RD_Disciplina { get; set; }

        [ForeignKey("FK_RD_RA")]
        public RegistroAcademicoDAO Registro_Academico { get; set; }

        [ForeignKey("FK_RD_Disciplina")]
        public DisciplinaDAO Disciplina { get; set; }
    }
}
