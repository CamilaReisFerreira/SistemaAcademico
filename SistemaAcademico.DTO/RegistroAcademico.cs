﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.DTO
{
    public class RegistroAcademico
    {
        public int Codigo { get; set; }

        public int Numero_Matricula { get; set; }

        public string Semestre { get; set; }

        public Aluno Aluno { get; set; }

        public Curso Curso { get; set; }

        public IEnumerable<RegistroDisciplina> RegistroDisciplinas { get; set; }

        public IEnumerable<Nota> Notas { get; set; }
    }
}
