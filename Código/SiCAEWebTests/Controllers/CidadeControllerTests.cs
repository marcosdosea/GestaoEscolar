using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SiCAEWeb.Controllers;
using SiCAEWeb.Mappers;
using SiCAEWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiCAEWeb.Controllers.Tests
{
    [TestClass()]
    public class CidadeControllerTests
    {
        private static CidadeController controller;
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            //Arrange
            var mockService = new Mock<ICidadeService>();
            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new CidadeProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos()).Returns(GetTestsCidades());
            mockService.Setup(service => service.Obter(1)).Returns(GetTargetCidade());
            mockService.Setup(service => service.Editar(It.IsAny<Cidade>())).Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Cidade>())).Verifiable();
            controller = new CidadeController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<CidadeModel>));
            List<CidadeModel> lista = (List<CidadeModel>)viewResult.ViewData.Model;
            Assert.AreEqual(4, lista.Count);

        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CidadeModel));
            CidadeModel cidadeModel = (CidadeModel)viewResult.ViewData.Model;
            Assert.AreEqual("Nossa Senhora da Glória", cidadeModel.Nome);
            Assert.AreEqual(2804508, cidadeModel.CodIbge);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller.Create(GetNewCidade());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_InValid()
        {
            // Arrange
            controller.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller.Create(GetNewCidade());

            // Assert
            Assert.AreEqual(1, controller.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void EditTest_Post()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CidadeModel));
            CidadeModel cidadeModel = (CidadeModel)viewResult.ViewData.Model;
            Assert.AreEqual("Nossa Senhora da Glória", cidadeModel.Nome);
            Assert.AreEqual(2804508, cidadeModel.CodIbge);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetCidadeModel().idCidade, GetTargetCidadeModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(CidadeModel));
            CidadeModel cidadeModel = (CidadeModel)viewResult.ViewData.Model;
            Assert.AreEqual("Nossa Senhora da Glória", cidadeModel.Nome);
            Assert.AreEqual(2804508, cidadeModel.CodIbge);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetCidadeModel().idCidade, GetTargetCidadeModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static CidadeModel GetNewCidade()
        {
            return new CidadeModel
            {
                idCidade = 1,
                CodIbge = 2802908,
                Nome = "Itabaiana"
            };
        }
        private static Cidade GetTargetCidade()
        {
            return new Cidade
            {
                idCidade = 2,
                CodIbge = 2804508,
                Nome = "Nossa Senhora da Glória"
            };
        }

        private static CidadeModel GetTargetCidadeModel()
        {
            return new CidadeModel
            {
                idCidade = 3,
                CodIbge = 2803203,
                Nome = "Itaporanga d'Ajuda"
            };
        }

        private static IEnumerable<Cidade> GetTestsCidades()
        {
            return new List<Cidade>
            {
                new Cidade
                {
                    idCidade = 1,
                    CodIbge = 2802908,
                    Nome = "Itabaiana"
                },
                new Cidade
                {
                    idCidade = 2,
                    CodIbge = 2805406,
                    Nome = "Poço Redondo"
                },
                new Cidade
                {
                    idCidade = 3,
                    CodIbge = 2803203,
                    Nome = "Itaporanga d'Ajuda"
                },
                new Cidade
                {
                    idCidade = 4,
                    CodIbge = 2801207,
                    Nome = "Canindé de São Francisco"
                },

            };
        }
    }

}