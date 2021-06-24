using AutoMapper;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using SiCAEWeb.Mappers;
using Models;
using SiCAEWeb.Models;

namespace SiCAEWeb.Controllers.Tests
{
    [TestClass()]
    public class DiahoraControllerTests
    {
        private static DiahoraController controller;

        [ClassInitialize]

        public static void initialize(TestContext testcontext)
        {
            //Arrange
            var mockService = new Mock<IHorarioService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new HorarioProfile())).CreateMapper();

            mockService.Setup(service => service.ObterTodos()).Returns(GetTestDiahoras());
            mockService.Setup(service => service.Obter(1)).Returns(GetTargetDiahora());
            mockService.Setup(service => service.Editar(It.IsAny<Diahora>())).Verifiable();
            mockService.Setup(service => service.Inserir(It.IsAny<Diahora>())).Verifiable();
            controller = new DiahoraController(mockService.Object, mapper);
        }
        [TestMethod()]
        [TestCategory("Unit")]
        [Description("Testando o Index")]
        public void IndexTest()
        {
            // Act
            var result = controller.Index();

            //Assert
            Assert.IsInstanceOfType(result, typeof(Microsoft.AspNetCore.Mvc.ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<DiahoraModel>));
            List <DiahoraModel> lista = (List<DiahoraModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller.Details(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DiahoraModel));
			DiahoraModel diahoraModel = (DiahoraModel)viewResult.ViewData.Model;
			Assert.AreEqual("SEG", diahoraModel.DiaSemana);
			Assert.AreEqual(TimeSpan.Parse("12:00"), diahoraModel.HorarioInicio);
			Assert.AreEqual(TimeSpan.Parse("12:50"), diahoraModel.HorarioTermino);
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
			var result = controller.Create(GetNewHorario());

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
			var result = controller.Create(GetNewHorario());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DiahoraModel));
			DiahoraModel diahoraModel = (DiahoraModel)viewResult.ViewData.Model;
			Assert.AreEqual("SEG", diahoraModel.DiaSemana);
			Assert.AreEqual(TimeSpan.Parse("12:00"), diahoraModel.HorarioInicio);
			Assert.AreEqual(TimeSpan.Parse("12:50"), diahoraModel.HorarioTermino);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetDiahoraModel().IdDiahora, GetTargetDiahoraModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(DiahoraModel));
			DiahoraModel diahoraModel = (DiahoraModel)viewResult.ViewData.Model;
			Assert.AreEqual(TimeSpan.Parse("12:00"), diahoraModel.HorarioInicio);
			Assert.AreEqual(TimeSpan.Parse("12:50"), diahoraModel.HorarioTermino);
			Assert.AreEqual("SEG", diahoraModel.DiaSemana);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetDiahoraModel().IdDiahora, GetTargetDiahoraModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static DiahoraModel GetNewHorario()
		{
			return new DiahoraModel
			{
				IdDiahora = 4,
				HorarioInicio = TimeSpan.Parse("07:00"),
				HorarioTermino = TimeSpan.Parse("08:50"),
				DiaSemana = "QUI",
			};

		}
		private static Diahora GetTargetDiahora()
		{
			return new Diahora
			{
				IdDiaHora = 1,
				HorarioInicio = TimeSpan.Parse("12:00"),
				HorarioTermino = TimeSpan.Parse("12:50"),
				DiaSemana = "SEG"
			};
		}

		private static DiahoraModel GetTargetDiahoraModel()
		{
			return new DiahoraModel
			{
				IdDiahora = 2,
				HorarioInicio = TimeSpan.Parse("12:00"),
				HorarioTermino = TimeSpan.Parse("12:50"),
				DiaSemana = "SEG"
			};
		}

		private static IEnumerable<Diahora> GetTestDiahoras()
		{
			return new List<Diahora>
			{
				new Diahora
				{
					IdDiaHora = 1,
					HorarioInicio = TimeSpan.Parse("09:00"),
					HorarioTermino = TimeSpan.Parse("10:50"),
					DiaSemana = "SEX"
				},
				new Diahora
				{
					IdDiaHora = 2,
					HorarioInicio = TimeSpan.Parse("12:00"),
					HorarioTermino = TimeSpan.Parse("12:50"),
					DiaSemana = "SEG"
				},
				new Diahora
				{
					IdDiaHora = 3,
					HorarioInicio = TimeSpan.Parse("09:00"),
					HorarioTermino = TimeSpan.Parse("11:50"),
					DiaSemana ="QUA",
				},
			};
		}
	}
}