using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using SiCAEWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;

namespace SiCAEWeb.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaService _pessoaService;

        private readonly IMapper _mapper;



        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var pessoas = _pessoaService.BuscarPessoas();
            var pessoasVM = _mapper.Map<List<PessoaModel>>(pessoas);
            return View(pessoasVM);
        }

        [HttpGet]
        public IActionResult AdicionarPessoa()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdicionarPessoa(PessoaModel pessoaModel)
        {
            if (ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                _pessoaService.InserirPessoa(pessoa);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/Pessoa/AlterarPessoa/{IdPessoa:int}")]
        public IActionResult AlterarPessoa(int IdPessoa)
        {
            var pessoa = _pessoaService.BuscaPessoaID(IdPessoa);
            var pessoaVM = _mapper.Map<PessoaModel>(pessoa);
            return View(pessoaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AlterarPessoa (PessoaModel pessoaModel)
        {
            if(ModelState.IsValid)
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                _pessoaService.AlterarPessoa(pessoa); 
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("/Pessoa/ExcluirPessoa/{IdPessoa:int}")]
        public IActionResult ExcluirPesoa(int IdPessoa)
        {
            var pessoa = _pessoaService.BuscaPessoaID(IdPessoa);
            var pessoaVM = _mapper.Map<PessoaModel>(pessoa);
            return View(pessoaVM);
        }

        [HttpPost]
        [Route("/Pessoa/ExcluirPessoa/{IdPessoa:int}")]
        public IActionResult ExcluirPessoa(PessoaModel pessoaModel)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaModel);
            _pessoaService.ExcluirPessoa(pessoa);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/Pessoa/Detalhes/{IdPessoa:int}")]
        public IActionResult Detalhes(int IdPessoa)
        {
            var pessoa = _pessoaService.BuscaPessoaID(IdPessoa);
            var pessoaVM = _mapper.Map<PessoaModel>(pessoa);
            return View(pessoaVM);

        }
    }
}
