using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Entidades
{
    [Table("Aluno")]
    public class AlunoDAO
    {
        [Key]
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public int Id_Cidade { get; set; }

        public string CPF { get; set; }

        public DateTime Data_Nascimento { get; set; }
    }
}
