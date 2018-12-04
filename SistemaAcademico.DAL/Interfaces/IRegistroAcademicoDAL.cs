using SistemaAcademico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Interfaces
{
    public interface IRegistroAcademicoDAL
    {
        IList<RegistroAcademico> ListarRegistrosAcademicos();

        void Add(RegistroAcademico item);

        void Update(RegistroAcademico item);

        void Delete(int Id);

        RegistroAcademico GetRegistroAcademico(int Id);
    }
}
