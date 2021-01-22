using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace SiCAEWeb.Controllers
{
	public class TurmaController : Controller
	{
		ITurmaService _turmaService;
		IMapper _mapper;

		public TurmaController(ITurmaService turmaService, IMapper mapper)
		{
			_turmaService = turmaService;
			_mapper = mapper;
		}

		// GET: TurmaController
		public ActionResult Index()
		{
			var listaTurmas = _turmaService.ObterTodos();
			var listaTurmasModel = _mapper.Map<List<TurmaModel>>(listaTurmas);
			return View(listaTurmasModel);
		}

		// GET: TurmaController/Details/5
		public ActionResult Details(int id)
		{
			Turma turma = _turmaService.Buscar(id);
			TurmaModel turmaModel = _mapper.Map<TurmaModel>(turma);
			return View(turmaModel);
		}

		// GET: TurmaController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: TurmaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(TurmaModel turmaModel)
		{
			if (ModelState.IsValid) {
				var turma = _mapper.Map<Turma>(turmaModel);
				_turmaService.Inserir(turma);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: TurmaController/Edit/5
		public ActionResult Edit(int id)
		{
            Turma turma = _turmaService.Buscar(id);
            TurmaModel turmaModel = _mapper.Map<TurmaModel>(turma);
			return View(turmaModel);
		}

        // POST: TurmaController/Edit/5
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, TurmaModel turmaModel)
		{
			if (ModelState.IsValid)
			{
				var turma = _mapper.Map<Turma>(turmaModel);
				_turmaService.Editar(turma);
			}
			return RedirectToAction(nameof(Index));
		}

        // GET: TurmaController/Delete/5
        public ActionResult Delete(int id)
		{
            Turma turma = _turmaService.Buscar(id);
            TurmaModel turmaModel = _mapper.Map<TurmaModel>(turma);
			return View(turmaModel);
		}

        // POST: TurmaController/Delete/5
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, TurmaModel turmaModel)
		{
			_turmaService.Remover(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
