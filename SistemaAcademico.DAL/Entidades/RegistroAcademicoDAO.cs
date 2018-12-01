using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Entidades
{
    [Table("RegistroAcademico")]
    public class RegistroAcademicoDAO
    {
        [Key]
        public int Codigo { get; set; }

        public int Numero_Matricula { get; set; }

        public string Semestre { get; set; }

        public int Id_Aluno { get; set; }

        public int Id_Curso { get; set; }

    }
}
