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
    public class CidadeDAL : ICidadeDAL
    {
        private readonly EFContext _context;

        public CidadeDAL(EFContext context)
        {
            _context = context;
        }

        public void Add(Cidade item)
        {
            var cidade = new CidadeDAO
            {
                Nome = item.Nome,
                UF = item.UF
            };

            _context.Cidades.Add(cidade);
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            CidadeDAO cidade = _context.Cidades.FirstOrDefault(x => x.Codigo == Id);

            _context.Cidades.Remove(cidade);
            _context.SaveChanges();
        }

        public Cidade GetCidade(int Id)
        {
            CidadeDAO cidade = _context.Cidades.Find(Id);
            return cidade != null ?
                new Cidade {
                    Codigo = cidade.Codigo,
                    Nome = cidade.Nome,
                    UF = cidade.UF } : null;
        }

        public IList<Cidade> ListarCidades()
        {
            List<Cidade> cidades =
            (from item in _context.Cidades
             orderby item.Nome
             select new Cidade()
             {
                 Codigo = item.Codigo,
                 Nome = item.Nome,
                 UF = item.UF
             }).ToList();
            return cidades;
        }

        public void Update(Cidade item)
        {
            CidadeDAO cidades = _context.Cidades.FirstOrDefault(x => x.Codigo == item.Codigo);
            cidades.Nome = item.Nome;
            cidades.UF = item.UF;
            _context.SaveChanges();
        }
    }
}
