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
    }
}
