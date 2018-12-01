using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DTO
{
    public class Aluno
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public int Id_Cidade { get; set; }

        public string CPF { get; set; }

        public DateTime Data_Nascimento { get; set; }

        public Cidade Cidade { get; set; }
    }
}
