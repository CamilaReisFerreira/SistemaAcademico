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
    public class CursoDAL : ICursoDAL
    {
        private readonly EFContext _context;

        public CursoDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(Curso item)
        {
            var curso = new CursoDAO
            {
                Nome = item.Nome,
                Data_Inicio = item.Data_Inicio,
                Carga_Horaria = item.Carga_Horaria
            };

            _context.Cursos.Add(curso);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            CursoDAO curso = _context.Cursos.FirstOrDefault(x => x.Codigo == Id);

            _context.Cursos.Remove(curso);
            _context.SaveChanges();
        }

        public Curso GetCurso(int Id)
        {
            CursoDAO curso = _context.Cursos.Find(Id);
            return curso != null ?
                new Curso {
                    Codigo = curso.Codigo,
                    Nome = curso.Nome,
                    Data_Inicio = curso.Data_Inicio,
                    Carga_Horaria = curso.Carga_Horaria } : null;
        }

        public IList<Curso> ListarCursos()
        {
            List<Curso> cursos =
            (from item in _context.Cursos
             orderby item.Nome
             select new Curso()
             {
                 Codigo = item.Codigo,
                 Nome = item.Nome,
                 Data_Inicio = item.Data_Inicio,
                 Carga_Horaria = item.Carga_Horaria
             }).ToList();
            return cursos;
        }

        public void Update(Curso item)
        {
            CursoDAO cursos = _context.Cursos.FirstOrDefault(x => x.Codigo == item.Codigo);
            cursos.Nome = item.Nome;
            cursos.Data_Inicio = item.Data_Inicio;
            cursos.Carga_Horaria = item.Carga_Horaria;
            _context.SaveChanges();
        }
    }
}
