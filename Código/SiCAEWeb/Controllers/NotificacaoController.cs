using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using SiCAEWeb.Models;
using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace SiCAEWeb.Controllers
{
    public class NotificacaoController : Controller
    {
        private readonly INotificacaoService _notificacaoService;

        private readonly IMapper _mapper;

        public NotificacaoController(INotificacaoService notificacaoService, IMapper mapper)
        {
            _notificacaoService = notificacaoService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var notificacoes = _notificacaoService.BuscarNotificacoes();
            var notificacoesVM = _mapper.Map<List<NotificacaoModel>>(notificacoes);
            return View(notificacoesVM);
        }
        [HttpGet]
        public IActionResult ExcluirNotificacao(int IdNotificacao)
        {
            var notificacao = _notificacaoService.BuscarNotificacaoId(IdNotificacao);
            var notificacaoVM = _mapper.Map<NotificacaoModel>(notificacao);
            return View(notificacaoVM);
        }

        [HttpPost]
        public IActionResult ExcluirNotificacao(NotificacaoModel notificacaoModel)
        {
            var notificacao = _mapper.Map<Notificacao>(notificacaoModel);
            _notificacaoService.ExcluirNotificacao(notificacao);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detalhes(int IdNotificacao)
        {
            var notificacao = _notificacaoService.BuscarNotificacaoId(IdNotificacao);
            var notificacaoVM = _mapper.Map<NotificacaoModel>(notificacao);
            return View(notificacaoVM);

        }
        

    }

}
