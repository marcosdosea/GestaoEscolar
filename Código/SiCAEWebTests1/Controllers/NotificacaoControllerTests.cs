using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiCAEWeb.Mappers;
using SiCAEWeb.Models;
using System.Collections.Generic;

namespace SiCAEWeb.Controllers.Tests
{
    [TestClass()]
    public class NotificacaoControllerTests
    {
        private static NotificacaoController _notificacaoController;
        private static Mock<INotificacaoService> _notificacaoService;
        private static IMapper _mapper;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            _notificacaoService = new Mock<INotificacaoService>();
            _mapper = new MapperConfiguration(config => config.AddProfile(new NotificacaoProfile())).CreateMapper();
            _notificacaoController = new NotificacaoController(_notificacaoService.Object, _mapper);
        }

        [TestMethod()]
        public void Index()
        {
            //Arrange
            var notificacoes = new List<Notificacao>() 
            { 
                new Notificacao() 
            };
            _notificacaoService.Setup(_ => _.BuscarNotificacoes())
                               .Returns(notificacoes);

            //Act
            var resposta = _notificacaoController.Index();
            var notificacoesVM = ((ViewResult)resposta).ViewData.Model as List<NotificacaoModel>;

            //Assert
            Assert.IsInstanceOfType(resposta, typeof(ActionResult));
            Assert.AreEqual(notificacoes.Count, _mapper.Map<List<Notificacao>>(notificacoesVM).Count);
        }

        [TestMethod()]
        public void AdicionarNotificacaoTest()
        {
            //Arrange
            var notificaoModel = new NotificacaoModel()
            {
                descricao = "Desc",
                titulo = "Tit",
                notificaProfessor = false,
                notificaAluno = true,
                prioridade = "Alta",
                remetente = "Julia",
                notificaResponsavel = false
            };

            //Act
            var resposta = _notificacaoController.AdicionarNotificacao(notificaoModel);

            //Assert
            Assert.IsInstanceOfType(resposta, typeof(RedirectToActionResult));
        }

        [TestMethod()]
        public void AlterarNotificacao()
        {
            //Arrange
            var notificacaoModel = new NotificacaoModel
            {
                idNotificacao = "1"
            };
            var notificacao = _mapper.Map<Notificacao>(notificacaoModel);

            _notificacaoService.Setup(_ => _.BuscarNotificacaoId(int.Parse(notificacaoModel.idNotificacao)))
                               .Returns(notificacao);

            //Act
            var resposta_GET = _notificacaoController.AlterarNotificacao(notificacao.IdNotificacao);
            var resposta_POST = _notificacaoController.AlterarNotificacao(notificacaoModel);

            //Assert
            Assert.IsInstanceOfType(resposta_GET, typeof(ActionResult));
            var notificacaoResposta_GET = ((ViewResult)resposta_GET).ViewData.Model as NotificacaoModel;
            Assert.AreEqual(notificacaoModel.idNotificacao, notificacaoResposta_GET.idNotificacao);

            Assert.IsInstanceOfType(resposta_POST, typeof(RedirectToActionResult));
        }

        [TestMethod()]
        public void ExcluirNotificacao()
        {
            //Arrange
            var notificacaoModel = new NotificacaoModel
            {
                idNotificacao = "1"
            };
            var notificacao = _mapper.Map<Notificacao>(notificacaoModel);

            _notificacaoService.Setup(_ => _.BuscarNotificacaoId(int.Parse(notificacaoModel.idNotificacao)))
                               .Returns(notificacao);

            //Act
            var resposta_GET = _notificacaoController.ExcluirNotificacao(notificacao.IdNotificacao);
            var resposta_POST = _notificacaoController.ExcluirNotificacao(notificacaoModel);

            //Assert
            Assert.IsInstanceOfType(resposta_GET, typeof(ActionResult));
            var notificacaoResposta_GET = ((ViewResult)resposta_GET).ViewData.Model as NotificacaoModel;
            Assert.AreEqual(notificacaoModel.idNotificacao, notificacaoResposta_GET.idNotificacao);

            Assert.IsInstanceOfType(resposta_POST, typeof(RedirectToActionResult));
        }
    }
}