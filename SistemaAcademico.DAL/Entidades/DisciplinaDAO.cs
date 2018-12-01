using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Entidades
{
    [Table("Disciplina")]
    public class DisciplinaDAO
    {
        [Key]
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public decimal Valor { get; set; }
    }
}
