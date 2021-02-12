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
    }
}
