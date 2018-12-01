using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Entidades
{
    [Table("Cidade")]
    public class CidadeDAO
    {
        [Key]
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string UF { get; set; }
    }
}
