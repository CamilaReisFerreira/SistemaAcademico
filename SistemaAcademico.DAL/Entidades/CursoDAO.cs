using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Entidades
{
    [Table("Curso")]
    public class CursoDAO
    {
        [Key]
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime Data_Inicio { get; set; }

        public decimal Carga_Horaria { get; set; }
    }
}
