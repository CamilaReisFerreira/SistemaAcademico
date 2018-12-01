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
    public class AlunoDAL : IAlunoDAL
    {
        private readonly EFContext _context;

        public AlunoDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(Aluno item)
        {
            var aluno = new AlunoDAO
            {
                Nome = item.Nome,
                Sobrenome = item.Sobrenome,
                CPF = item.CPF,
                Data_Nascimento = item.Data_Nascimento
            };
            if (item.Cidade != null)
                aluno.FK_Aluno_Cidade = item.Cidade.Codigo;

            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            AlunoDAO aluno = _context.Alunos.FirstOrDefault(x => x.Codigo == Id);

            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

        public Aluno GetAluno(int Id)
        {
            AlunoDAO aluno = _context.Alunos.Find(Id);
            var cidade = aluno.FK_Aluno_Cidade != null ? _context.Cidades.Find(aluno.FK_Aluno_Cidade) : null;

            return aluno != null ?
                new Aluno {
                    Codigo = aluno.Codigo,
                    Nome = aluno.Nome,
                    Sobrenome = aluno.Sobrenome,
                    CPF = aluno.CPF,
                    Data_Nascimento = aluno.Data_Nascimento,
                    Cidade = cidade != null ? new Cidade
                    {
                        Codigo = cidade.Codigo,
                        Nome = cidade.Nome,
                        UF = cidade.UF
                    } : null,
                } : null;
        }

        public IList<Aluno> ListarAlunos()
        {
            List<Aluno> alunos =
            (from item in _context.Alunos
             orderby item.Nome
             select new Aluno()
             {
                 Codigo = item.Codigo,
                 Nome = item.Nome,
                 Sobrenome = item.Sobrenome,
                 CPF = item.CPF,
                 Data_Nascimento = item.Data_Nascimento,
                 Cidade = item.Cidade != null ? new Cidade
                 {
                     Codigo = item.Cidade.Codigo,
                     Nome = item.Cidade.Nome,
                     UF = item.Cidade.UF
                 } : null,
             }).ToList();
            return alunos;
        }

        public void Update(Aluno item)
        {
            AlunoDAO alunos = _context.Alunos.FirstOrDefault(x => x.Codigo == item.Codigo);

            alunos.Nome = item.Nome;
            alunos.Sobrenome = item.Sobrenome;
            alunos.CPF = item.CPF;
            alunos.Data_Nascimento = item.Data_Nascimento;
            if (item.Cidade != null)
                alunos.FK_Aluno_Cidade = item.Cidade.Codigo;

            _context.SaveChanges();
        }
    }
}
