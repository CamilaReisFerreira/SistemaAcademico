using SistemaAcademico.DAL.Context;
using SistemaAcademico.DAL.Entidades;
using SistemaAcademico.DAL.Interfaces;
using SistemaAcademico.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaAcademico.DAL.Persistencia
{
    public class DisciplinaDAL : IDisciplinaDAL
    {
        private readonly EFContext _context;

        public DisciplinaDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(Disciplina item)
        {
            var disciplina = new DisciplinaDAO
            {
                Nome = item.Nome,
                Valor = item.Valor
            };

            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            DisciplinaDAO disciplina = _context.Disciplinas.FirstOrDefault(x => x.Codigo == Id);

            _context.Disciplinas.Remove(disciplina);
            _context.SaveChanges();
        }

        public Disciplina GetDisciplina(int Id)
        {
            DisciplinaDAO disciplina = _context.Disciplinas.Find(Id);
            return disciplina != null ?
                new Disciplina
                {
                    Codigo = disciplina.Codigo,
                    Nome = disciplina.Nome,
                    Valor = disciplina.Valor
                } : null;
        }

        public IList<Disciplina> ListarDisciplinas()
        {
            List<Disciplina> disciplinas =
            (from item in _context.Disciplinas
             orderby item.Nome
             select new Disciplina()
             {
                 Codigo = item.Codigo,
                 Nome = item.Nome,
                 Valor = item.Valor
             }).ToList();
            return disciplinas;
        }

        public void Update(Disciplina item)
        {
            DisciplinaDAO disciplinas = _context.Disciplinas.FirstOrDefault(x => x.Codigo == item.Codigo);
            disciplinas.Nome = item.Nome;
            disciplinas.Valor = item.Valor;
            _context.SaveChanges();
        }
    }
}

