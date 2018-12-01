using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.DAL.Interfaces;
using SistemaAcademico.DTO;

namespace SistemaAcademico.Controllers
{
    public class AlunoController : Controller
    {
        public IAlunoDAL AlunoRepo { get; set; }
        public ICidadeDAL CidadeRepo { get; set; }

        public AlunoController(IAlunoDAL _repo, ICidadeDAL _cidadeRepo)
        {
            AlunoRepo = _repo;
            CidadeRepo = _cidadeRepo;
        }


        public IActionResult Index()
        {
            return View(AlunoRepo.ListarAlunos());
        }

        public IActionResult Create()
        {
            ViewBag.Cidades = CidadeRepo.ListarCidades();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aluno aluno)
        {
            AlunoRepo.Add(aluno);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Aluno aluno = AlunoRepo.GetAluno(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }
            ViewBag.Cidades = CidadeRepo.ListarCidades();
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                AlunoRepo.Update(aluno);
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
            Aluno aluno = AlunoRepo.GetAluno(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Aluno aluno)
        {
            Aluno alu = AlunoRepo.GetAluno(aluno.Codigo);
            if (alu != null)
            {
                AlunoRepo.Delete(aluno.Codigo);
                TempData["Message"] = "Aluno " + alu.Nome + " foi removido";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Aluno aluno = AlunoRepo.GetAluno(id.Value);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
    }
}