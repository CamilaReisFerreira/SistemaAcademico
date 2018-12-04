using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.DAL.Interfaces;
using SistemaAcademico.DTO;

namespace SistemaAcademico.Controllers
{
    public class RegistroAcademicoController : Controller
    {
        public IRegistroAcademicoDAL RegistroAcademicoRepo { get; set; }
        public IDisciplinaDAL DisciplinaRepo { get; set; }

        public RegistroAcademicoController(IRegistroAcademicoDAL _repo, IDisciplinaDAL _disciplinaRepo)
        {
            RegistroAcademicoRepo = _repo;
            DisciplinaRepo = _disciplinaRepo;
        }


        public IActionResult Index()
        {
            return View(RegistroAcademicoRepo.ListarRegistrosAcademicos());
        }

        public IActionResult Create()
        {
            ViewBag.Disciplinas = DisciplinaRepo.ListarDisciplinas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistroAcademico aluno)
        {
            RegistroAcademicoRepo.Add(aluno);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            RegistroAcademico aluno = RegistroAcademicoRepo.GetRegistroAcademico(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewBag.Disciplinas = DisciplinaRepo.ListarDisciplinas();
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RegistroAcademico aluno)
        {
            if (ModelState.IsValid)
            {
                RegistroAcademicoRepo.Update(aluno);
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            RegistroAcademico aluno = RegistroAcademicoRepo.GetRegistroAcademico(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(RegistroAcademico aluno)
        {
            RegistroAcademico alu = RegistroAcademicoRepo.GetRegistroAcademico(aluno.Codigo);
            if (alu != null)
            {
                RegistroAcademicoRepo.Delete(aluno.Codigo);
                TempData["Message"] = "RegistroAcademico " + alu.Numero_Matricula + " foi removido";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            RegistroAcademico aluno = RegistroAcademicoRepo.GetRegistroAcademico(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddDisciplina(Disciplina aluno)
        {
            //RegistroAcademicoRepo.Add(aluno);
            return View();
        }
    }
}