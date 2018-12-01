using SistemaAcademico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Interfaces
{
    public interface IDisciplinaDAL
    {
        IList<Disciplina> ListarDisciplinas();

        void Add(Disciplina item);

        void Update(Disciplina item);

        void Delete(int Id);

        Disciplina GetDisciplina(int Id);
    }
}
