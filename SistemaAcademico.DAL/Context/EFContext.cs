using Microsoft.EntityFrameworkCore;
using SistemaAcademico.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DAL.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options) { }

        public DbSet<AlunoDAO> Alunos { get; set; }
        public DbSet<CidadeDAO> Cidades { get; set; }
        public DbSet<CursoDAO> Cursos { get; set; }
        public DbSet<DisciplinaDAO> Disciplinas { get; set; }
        public DbSet<NotaDAO> Notas { get; set; }
        public DbSet<RegistroAcademicoDAO> RegistrosAcademicos { get; set; }
        public DbSet<RegistroDisciplinaDAO> RegistrosDisciplinas { get; set; }
    }
}
