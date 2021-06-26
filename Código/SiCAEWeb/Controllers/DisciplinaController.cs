using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service;
using SiCAEWeb.Models;
using Core;

namespace SiCAEWeb.Controllers
{
    public class DisciplinaController : Controller
    {
        IDisciplinaService _disciplinaService;
        IMapper _mapper;

        public DisciplinaController(IDisciplinaService disciplinaService, IMapper mapper)
        {
            _disciplinaService = disciplinaService;
            _mapper = mapper;
        }

        // GET: DisciplinaController
        public ActionResult Index()
        {
            var listaDisciplinas = _disciplinaService.ObterTodos();
            var listaDisciplinasModel = _mapper.Map<List<DisciplinaModel>>(listaDisciplinas);
            return View(listaDisciplinasModel);
        }

        // GET: DisciplinaController/Details/5
        public ActionResult Details(int id)
        {
            Disciplina disciplina = _disciplinaService.Obter(id);
            DisciplinaModel disciplinaModel = _mapper.Map<DisciplinaModel>(disciplina);
            return View(disciplinaModel);
        }

        // GET: DisciplinaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisciplinaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DisciplinaModel disciplinaModel)
        {
            if (ModelState.IsValid)
            {
                var disciplina = _mapper.Map<Disciplina>(disciplinaModel);
                _disciplinaService.Inserir(disciplina);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DisciplinaController/Edit/5
        public ActionResult Edit(int id)
        {
            Disciplina disciplina = _disciplinaService.Obter(id);
            DisciplinaModel disciplinaModel = _mapper.Map<DisciplinaModel>(disciplina);
            return View(disciplinaModel);
        }

        // POST: DisciplinaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DisciplinaModel disciplinaModel)
        {
            if (ModelState.IsValid)
            {
                var disciplina = _mapper.Map<Disciplina>(disciplinaModel);
                _disciplinaService.Editar(disciplina);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DisciplinaController/Delete/5
        public ActionResult Delete(int id)
        {
            Disciplina disciplina = _disciplinaService.Obter(id);
            DisciplinaModel disciplinaModel = _mapper.Map<DisciplinaModel>(disciplina);
            return View(disciplinaModel);
        }

        // POST: DisciplinaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DisciplinaModel disciplinaModel)
        {
            _disciplinaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
