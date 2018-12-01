using SistemaAcademico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Interfaces
{
    public interface ICursoDAL
    {
        IList<Curso> ListarCursos();

        void Add(Curso item);

        void Update(Curso item);

        void Delete(int Id);

        Curso GetCurso(int Id);
    }
}
