using SistemaAcademico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Interfaces
{
    public interface ICidadeDAL
    {
        IList<Cidade> ListarCidades();

        void Add(Cidade item);

        void Update(Cidade item);

        void Delete(int Id);

        Cidade GetCidade(int Id);
    }
}
