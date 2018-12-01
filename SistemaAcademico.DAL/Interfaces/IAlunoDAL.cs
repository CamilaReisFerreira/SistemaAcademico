using SistemaAcademico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Interfaces
{
    public interface IAlunoDAL
    {
        IList<Aluno> ListarAlunos();

        void Add(Aluno item);

        void Update(Aluno item);

        void Delete(int Id);

        Aluno GetAluno(int Id);
    }
}
