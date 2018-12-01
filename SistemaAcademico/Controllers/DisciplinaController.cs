using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.DAL.Interfaces;
using SistemaAcademico.DTO;

namespace SistemaAcademico.Controllers
{
    public class DisciplinaController : Controller
    {
        public IDisciplinaDAL DisciplinaRepo { get; set; }

        public DisciplinaController(IDisciplinaDAL _repo)
        {
            DisciplinaRepo = _repo;
        }


        public IActionResult Index()
        {
            return View(DisciplinaRepo.ListarDisciplinas());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Disciplina disciplina)
        {
            DisciplinaRepo.Add(disciplina);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Disciplina disciplina = DisciplinaRepo.GetDisciplina(id.Value);
            if (disciplina == null)
            {
                return NotFound();
            }
            return View(disciplina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                DisciplinaRepo.Update(disciplina);
                return RedirectToAction("Index");
            }
            return View(disciplina);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Disciplina disciplina = DisciplinaRepo.GetDisciplina(id.Value);
            if (disciplina == null)
            {
                return NotFound();
            }
            return View(disciplina);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Disciplina disciplina)
        {
            Disciplina dis = DisciplinaRepo.GetDisciplina(disciplina.Codigo);
            if (dis != null)
            {
                DisciplinaRepo.Delete(disciplina.Codigo);
                TempData["Message"] = "Disciplina " + dis.Nome + " foi removida";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Disciplina disciplina = DisciplinaRepo.GetDisciplina(id.Value);
            if (disciplina == null)
            {
                return NotFound();
            }
            return View(disciplina);
        }
    }
}