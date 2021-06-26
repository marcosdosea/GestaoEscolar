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
    public class DisciplinaControllerTests
    {
        private static DisciplinaController controller;

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            //Arrange
            var mockService = new Mock<IDisciplinaService>();
            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new DisciplinaProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos()).Returns(GetTestsDisciplinas());
            mockService.Setup(service => service.Obter(1)).Returns(GetTargetDisciplina());
            mockService.Setup(service => service.Editar(It.IsAny<Disciplina>())).Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Disciplina>())).Verifiable();
            controller = new DisciplinaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<DisciplinaModel>));
            List<DisciplinaModel> lista = (List<DisciplinaModel>)viewResult.ViewData.Model;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisciplinaModel));
            DisciplinaModel disciplinaModel = (DisciplinaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Português", disciplinaModel.Nome);
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
            var result = controller.Create(GetNewDisciplina());

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
            var result = controller.Create(GetNewDisciplina());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisciplinaModel));
            DisciplinaModel disciplinaModel = (DisciplinaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Português", disciplinaModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Get()
        {
            // Act
            var result = controller.Edit(GetTargetDisciplinaModel().IdDisciplina, GetTargetDisciplinaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DisciplinaModel));
            DisciplinaModel disciplinaModel = (DisciplinaModel)viewResult.ViewData.Model;
            Assert.AreEqual("Português", disciplinaModel.Nome);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetTargetDisciplinaModel().IdDisciplina, GetTargetDisciplinaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static DisciplinaModel GetNewDisciplina()
        {
            return new DisciplinaModel
            {
                IdDisciplina = 1,
                Nome = "Matemática"
            };
        }
        private static Disciplina GetTargetDisciplina()
        {
            return new Disciplina
            {
                IdDisciplina = 2,
                Nome = "Português"
            };
        }

        private static DisciplinaModel GetTargetDisciplinaModel()
        {
            return new DisciplinaModel
            {
                IdDisciplina = 3,
                Nome = "Biologia"
            };
        }

        private static IEnumerable<Disciplina> GetTestsDisciplinas()
        {
            return new List<Disciplina>
            {
                new Disciplina
                {
                    IdDisciplina = 1,
                    Nome = "Matemática"
                },
                new Disciplina
                {
                    IdDisciplina = 2,
                    Nome = "Português"
                },
                new Disciplina
                {
                    IdDisciplina = 3,
                    Nome = "Biologia"
                },
                new Disciplina
                {
                    IdDisciplina = 4,
                    Nome = "Geografia"
                },
                
            };
        }
    }

}