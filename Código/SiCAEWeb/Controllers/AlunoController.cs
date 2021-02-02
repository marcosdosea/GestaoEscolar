using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using SiCAEWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace SiCAEWeb.Controllers
{
    public class AlunoController : Controller
    {
        IAlunoService _alunoService;
        IMapper _mapper;
        // GET: DiahoraController
        public AlunoController(IAlunoService alunoService, IMapper mapper)
        {
            _alunoService = alunoService;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var listaAlunos = _alunoService.ObterTodos().ToList();
            var listaAlunosModel = _mapper.Map<List<AlunoModel>>(listaAlunos);
            return View(listaAlunosModel);
        }

        // GET: AlunoController/Details/5
        public ActionResult Details(int id)
        {
            Aluno aluno = _alunoService.Obter(id);
            AlunoModel alunoModel = _mapper.Map<AlunoModel>(aluno);
            return View(alunoModel);
        }

        // GET: AlunoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiahoraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                var aluno = _mapper.Map<Aluno>(alunoModel);
                _alunoService.Inserir(aluno);
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: AlunoController/Edit/5
        public ActionResult Edit(int id)
        {
            Aluno aluno = _alunoService.Obter(id);
            AlunoModel alunoModel = _mapper.Map<AlunoModel>(aluno);
            return View(alunoModel);
        }

        // POST: AlunoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AlunoModel alunoModel)
        {
            if (ModelState.IsValid)
            {
                var aluno = _mapper.Map<Aluno>(alunoModel);
                _alunoService.Editar(aluno);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AlunoController/Delete/5
        public ActionResult Delete(int id)
        {
            Aluno aluno = _alunoService.Obter(id);
            AlunoModel alunoModel = _mapper.Map<AlunoModel>(aluno);
            return View(alunoModel);
        }

        // POST: AlunoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AlunoModel alunoModel)
        {
            _alunoService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
