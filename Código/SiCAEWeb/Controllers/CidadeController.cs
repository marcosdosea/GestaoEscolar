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
    public class CidadeController : Controller
    {
        ICidadeService _cidadeService;
        IMapper _mapper;

        public CidadeController(ICidadeService cidadeService, IMapper mapper)
        {
            _cidadeService = cidadeService;
            _mapper = mapper;
        }

        // GET: CidadeController
        public ActionResult Index()
        {
            var listaCidades = _cidadeService.ObterTodos();
            var listaCidadesModel = _mapper.Map<List<CidadeModel>>(listaCidades);
            return View(listaCidadesModel);
        }

        // GET: CidadeController/Details/5
        public ActionResult Details(int id)
        {
            Cidade cidade = _cidadeService.Obter(id);
            CidadeModel cidadeModel = _mapper.Map<CidadeModel>(cidade);
            return View(cidadeModel);
        }

        // GET: CidadeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CidadeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CidadeModel cidadeModel)
        {
            if (ModelState.IsValid)
            {
                var cidade = _mapper.Map<Cidade>(cidadeModel);
                _cidadeService.Inserir(cidade);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CidadeController/Edit/5
        public ActionResult Edit(int id)
        {
            Cidade cidade = _cidadeService.Obter(id);
            CidadeModel cidadeModel = _mapper.Map<CidadeModel>(cidade);
            return View(cidadeModel);
        }

        // POST: CidadeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CidadeModel cidadeModel)
        {
            if (ModelState.IsValid)
            {
                var cidade = _mapper.Map<Cidade>(cidadeModel);
                _cidadeService.Editar(cidade);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: CidadeController/Delete/5
        public ActionResult Delete(int id)
        {
            Cidade cidade = _cidadeService.Obter(id);
            CidadeModel cidadeModel = _mapper.Map<CidadeModel>(cidade);
            return View(cidadeModel);
        }

        // POST: CidadeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CidadeModel cidadeModel)
        {
            _cidadeService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
