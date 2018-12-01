using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Entidades
{
    [Table("Nota")]
    public class NotaDAO
    {
        [Key]
        public int Codigo { get; set; }

        public decimal Nota1 { get; set; }

        public decimal Nota2 { get; set; }

        public decimal Nota3 { get; set; }

        public decimal Media { get; set; }

        public int? FK_Nota_RA { get; set; }

        public int? FK_Nota_Disciplina { get; set; }

        [ForeignKey("FK_Nota_RA")]
        public RegistroAcademicoDAO Registro_Academico { get; set; }

        [ForeignKey("FK_Nota_Disciplina")]
        public DisciplinaDAO Disciplina { get; set; }
    }
}
