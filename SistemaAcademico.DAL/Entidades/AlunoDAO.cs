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

        public string CPF { get; set; }

        public DateTime Data_Nascimento { get; set; }
        public int? FK_Aluno_Cidade { get; set; }

        [ForeignKey("FK_Aluno_Cidade")]
        public CidadeDAO Cidade { get; set; }
    }
}
