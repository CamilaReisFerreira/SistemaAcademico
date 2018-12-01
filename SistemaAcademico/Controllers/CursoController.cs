using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.DAL.Interfaces;
using SistemaAcademico.DTO;

namespace SistemaAcademico.Controllers
{
    public class CursoController : Controller
    {
        public ICursoDAL CursoRepo { get; set; }

        public CursoController(ICursoDAL _repo)
        {
            CursoRepo = _repo;
        }


        public IActionResult Index()
        {
            return View(CursoRepo.ListarCursos());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Curso curso)
        {
            CursoRepo.Add(curso);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Curso curso = CursoRepo.GetCurso(id.Value);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid)
            {
                CursoRepo.Update(curso);
                return RedirectToAction("Index");
            }
            return View(curso);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Curso curso = CursoRepo.GetCurso(id.Value);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Curso curso)
        {
            Curso cur = CursoRepo.GetCurso(curso.Codigo);
            if (cur != null)
            {
                CursoRepo.Delete(curso.Codigo);
                TempData["Message"] = "Curso " + cur.Nome + " foi removido";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Curso curso = CursoRepo.GetCurso(id.Value);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }
    }
}