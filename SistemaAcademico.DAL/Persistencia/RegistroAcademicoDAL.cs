using SistemaAcademico.DAL.Context;
using SistemaAcademico.DAL.Entidades;
using SistemaAcademico.DAL.Interfaces;
using SistemaAcademico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Persistencia
{
    public class RegistroAcademicoDAL : IRegistroAcademicoDAL
    {
        private readonly EFContext _context;

        public RegistroAcademicoDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(RegistroAcademico item)
        {
            //var aluno = new RegistroAcademicoDAO
            //{
            //    Nome = item.Nome,
            //    Sobrenome = item.Sobrenome,
            //    CPF = item.CPF,
            //    Data_Nascimento = item.Data_Nascimento
            //};
            //if (item.Cidade != null)
            //    aluno.FK_RegistroAcademico_Cidade = item.Cidade.Codigo;

            //_context.RegistrosAcademicos.Add(aluno);
            //_context.SaveChanges();
        }

        public void Delete(int Id)
        {
            RegistroAcademicoDAO aluno = _context.RegistrosAcademicos.FirstOrDefault(x => x.Codigo == Id);

            _context.RegistrosAcademicos.Remove(aluno);
            _context.SaveChanges();
        }

        public RegistroAcademico GetRegistroAcademico(int Id)
        {
            throw new NotImplementedException();
            //RegistroAcademicoDAO aluno = _context.RegistroAcademicos.Find(Id);
            //var cidade = aluno.FK_RegistroAcademico_Cidade != null ? _context.Cidades.Find(aluno.FK_RegistroAcademico_Cidade) : null;

            //return aluno != null ?
            //    new RegistroAcademico {
            //        Codigo = aluno.Codigo,
            //        Nome = aluno.Nome,
            //        Sobrenome = aluno.Sobrenome,
            //        CPF = aluno.CPF,
            //        Data_Nascimento = aluno.Data_Nascimento,
            //        Cidade = cidade != null ? new Cidade
            //        {
            //            Codigo = cidade.Codigo,
            //            Nome = cidade.Nome,
            //            UF = cidade.UF
            //        } : null,
            //    } : null;
        }

        public IList<RegistroAcademico> ListarRegistrosAcademicos()
        {
            throw new NotImplementedException();
            //List<RegistroAcademico> alunos =
            //(from item in _context.RegistroAcademicos
            // orderby item.Nome
            // select new RegistroAcademico()
            // {
            //     Codigo = item.Codigo,
            //     Nome = item.Nome,
            //     Sobrenome = item.Sobrenome,
            //     CPF = item.CPF,
            //     Data_Nascimento = item.Data_Nascimento,
            //     Cidade = item.Cidade != null ? new Cidade
            //     {
            //         Codigo = item.Cidade.Codigo,
            //         Nome = item.Cidade.Nome,
            //         UF = item.Cidade.UF
            //     } : null,
            // }).ToList();
            //return alunos;
        }

        public void Update(RegistroAcademico item)
        {
            //RegistroAcademicoDAO alunos = _context.RegistroAcademicos.FirstOrDefault(x => x.Codigo == item.Codigo);

            //alunos.Nome = item.Nome;
            //alunos.Sobrenome = item.Sobrenome;
            //alunos.CPF = item.CPF;
            //alunos.Data_Nascimento = item.Data_Nascimento;
            //if (item.Cidade != null)
            //    alunos.FK_RegistroAcademico_Cidade = item.Cidade.Codigo;

            //_context.SaveChanges();
        }
    }
}
