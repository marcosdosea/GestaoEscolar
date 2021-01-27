using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using SiCAEWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiCAEWeb.Controllers
{
    public class DiahoraController : Controller
    {
        IHorarioService _horarioService;
        IMapper _mapper;
        // GET: DiahoraController
        public DiahoraController(IHorarioService horarioService, IMapper mapper)
        {
            _horarioService = horarioService;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var listaHorarios = _horarioService.ObterTodos().ToList();
            var listaHorariosModel = _mapper.Map<List<DiahoraModel>>(listaHorarios);
            return View(listaHorariosModel);
        }

        // GET: DiahoraController/Details/5
        public ActionResult Details(int id)
        {
            Diahora diahora = _horarioService.Obter(id);
            DiahoraModel diahoraModel = _mapper.Map<DiahoraModel>(diahora);
            return View(diahoraModel);
        }

        // GET: DiahoraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiahoraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiahoraModel diahoraModel)
        {
            if (ModelState.IsValid)
            {
                var diahora = _mapper.Map<Diahora>(diahoraModel);
                diahora.HorarioInicio = diahoraModel.HorarioInicio;
                diahora.HorarioTermino = diahoraModel.HorarioTermino;
                _horarioService.Inserir(diahora);
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: DiahoraController/Edit/5
        public ActionResult Edit(int id)
        {
            Diahora diahora = _horarioService.Obter(id);
            DiahoraModel diahoraModel = _mapper.Map<DiahoraModel>(diahora);
            return View(diahoraModel);
        }

        // POST: DiahoraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DiahoraModel diahoraModel)
        {
            if (ModelState.IsValid)
            {
                var diahora = _mapper.Map<Diahora>(diahoraModel);
                _horarioService.Editar(diahora);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: DiahoraController/Delete/5
        public ActionResult Delete(int id)
        {
            Diahora diahora = _horarioService.Obter(id);
            DiahoraModel diahoraModel = _mapper.Map<DiahoraModel>(diahora);
            return View(diahoraModel);
        }

        // POST: DiahoraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DiahoraModel diahoraModel)
        {
            _horarioService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
