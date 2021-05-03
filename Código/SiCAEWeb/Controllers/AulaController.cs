using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiCAEWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiCAEWeb.Controllers
{
    public class AulaController : Controller
    {
        // GET: AulaController1
        IAulaService _aulaService;
        IMapper _mapper;

        public AulaController(IAulaService aulaService, IMapper mapper)
        {
            _aulaService = aulaService;
            _mapper = mapper;
        }

        // GET: CidadeController
        public ActionResult Index()
        {
            var listaAulas = _aulaService.ObterTodos();
            var listaAulasModel = _mapper.Map<List<AulaModel>>(listaAulas);
            return View(listaAulasModel);
        }

        // GET: CidadeController/Details/5
        public ActionResult Details(int id)
        {
            Aula aula = _aulaService.Obter(id);
            AulaModel aulaModel = _mapper.Map<AulaModel>(aula);
            return View(aulaModel);
        }

        // GET: CidadeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CidadeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AulaModel aulaModel)
        {
            if (ModelState.IsValid)
            {
                var aula = _mapper.Map<Aula>(aulaModel);
                _aulaService.Inserir(aula);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CidadeController/Edit/5
        public ActionResult Edit(int id)
        {
            Aula aula = _aulaService.Obter(id);
            AulaModel aulaModel = _mapper.Map<AulaModel>(aula);
            return View(aulaModel);
        }

        // POST: CidadeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AulaModel aulaModel)
        {
            if (ModelState.IsValid)
            {
                var aula = _mapper.Map<Aula>(aulaModel);
                _aulaService.Editar(aula);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CidadeController/Delete/5
        public ActionResult Delete(int id)
        {
            Aula aula = _aulaService.Obter(id);
            AulaModel aulaModel = _mapper.Map<AulaModel>(aula);
            return View(aulaModel);
        }

        // POST: CidadeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _aulaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
