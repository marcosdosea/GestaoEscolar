using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiCAEWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiCAEWeb.Controllers
{
    public class EscolaController : Controller
    {
        IEscolaService _escolaService;
        IMapper _mapper;

        public EscolaController(IEscolaService escolaService, IMapper mapper)
        {
            _escolaService = escolaService;
            _mapper = mapper;
        }

        // GET: EscolaController
        public ActionResult Index()
        {
            var listaEscolas = _escolaService.ObterTodos();
            var listaEscolasModel = _mapper.Map<List<EscolaModel>>(listaEscolas);
            return View(listaEscolasModel);
        }

        // GET: EscolaController/Details/5
        public ActionResult Details(int id)
        {
            Escola escola = _escolaService.Obter(id);
            EscolaModel escolaModel = _mapper.Map<EscolaModel>(escola);
            return View(escolaModel);
        }

        // GET: EscolaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EscolaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EscolaModel escolaModel)
        {
            if (ModelState.IsValid)
            {
                var escola = _mapper.Map<Escola>(escolaModel);
                _escolaService.Inserir(escola);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EscolaController/Edit/5
        public ActionResult Edit(int id)
        {
            Escola escola = _escolaService.Obter(id);
            EscolaModel escolaModel = _mapper.Map<EscolaModel>(escola);
            return View(escolaModel);
        }

        // POST: EscolaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EscolaModel escolaModel)
        {
            if (ModelState.IsValid)
            {
                var escola = _mapper.Map<Escola>(escolaModel);
                _escolaService.Inserir(escola);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EscolaController/Delete/5
        public ActionResult Delete(int id)
        {
            Escola escola = _escolaService.Obter(id);
            EscolaModel escolaModel = _mapper.Map<EscolaModel>(escola);
            return View(escolaModel);
        }

        // POST: EscolaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EscolaModel escolaModel)
        {
            _escolaService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}


