using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaAcademico.DAL.Interfaces;
using SistemaAcademico.DTO;

namespace SistemaAcademico.Controllers
{
    public class CidadeController : Controller
    {
        public ICidadeDAL CidadeRepo { get; set; }

        public CidadeController(ICidadeDAL _repo)
        {
            CidadeRepo = _repo;
        }


        public IActionResult Index()
        {
            return View(CidadeRepo.ListarCidades());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cidade cidade)
        {
            CidadeRepo.Add(cidade);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Cidade cidade = CidadeRepo.GetCidade(id.Value);
            if (cidade == null)
            {
                return NotFound();
            }
            return View(cidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                CidadeRepo.Update(cidade);
                return RedirectToAction("Index");
            }
            return View(cidade);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Cidade cidade = CidadeRepo.GetCidade(id.Value);
            if (cidade == null)
            {
                return NotFound();
            }
            return View(cidade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Cidade cidade)
        {
            Cidade cid = CidadeRepo.GetCidade(cidade.Codigo);
            if (cid != null)
            {
                CidadeRepo.Delete(cidade.Codigo);
                TempData["Message"] = "Cidade " + cid.Nome + " foi removida";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Cidade cidade = CidadeRepo.GetCidade(id.Value);
            if (cidade == null)
            {
                return NotFound();
            }
            return View(cidade);
        }
    }
}