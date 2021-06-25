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
	public class AlunoControllerTests
	{
		private static AlunoController controller;

		[ClassInitialize]

		public static void initialize(TestContext testcontext)
		{
			//Arrange
			var mockService = new Mock<IAlunoService>();

			IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new AlunoProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos()).Returns(GetTestAlunos());
			mockService.Setup(service => service.Obter(1)).Returns(GetTargetAluno());
			mockService.Setup(service => service.Editar(It.IsAny<Aluno>())).Verifiable();
			mockService.Setup(service => service.Inserir(It.IsAny<Aluno>())).Verifiable();
			controller = new AlunoController(mockService.Object, mapper);
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AlunoModel>));
			List<AlunoModel> lista = (List<AlunoModel>)viewResult.ViewData.Model;
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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AlunoModel));
			AlunoModel alunoModel = (AlunoModel)viewResult.ViewData.Model;
			Assert.AreEqual("", alunoModel.NomeSocial);
			Assert.AreEqual(DateTime.Parse("2005-02-02"), alunoModel.DataNascimento);
			Assert.AreEqual("14588756499", alunoModel.Cpf);
			Assert.AreEqual("Praca General Joao Pereira", alunoModel.Rua);
			Assert.AreEqual("49500000", alunoModel.Cep);
			Assert.AreEqual("Itabaiana", alunoModel.Cidade);
			Assert.AreEqual("Escola Estadual Dr. Airton Teles", alunoModel.ProcedenciaEscolar);
			Assert.AreEqual("Brasileiro", alunoModel.Nacionalidade);
			Assert.AreEqual("23409809", alunoModel.Identidade);
			Assert.AreEqual("79999443234", alunoModel.Telefone);
			Assert.AreEqual("M", alunoModel.Sexo);
			Assert.AreEqual("54765409897765612344556098779809", alunoModel.CertidaoNascimento);
			Assert.AreEqual("Branco", alunoModel.CorRaca);
			Assert.AreEqual("234098788908721", alunoModel.Sus);
			Assert.AreEqual("22356599001", alunoModel.Nis);
			Assert.AreEqual("Centro", alunoModel.Bairro);
			Assert.AreEqual("Proximo a ZapLanches", alunoModel.Complemento);
			Assert.AreEqual("765", alunoModel.NumeroImovel);
			Assert.AreEqual("Mauricio Santos Santana", alunoModel.Nome);
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
			var result = controller.Create(GetNewAluno());

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
			var result = controller.Create(GetNewAluno());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AlunoModel));
			AlunoModel alunoModel = (AlunoModel)viewResult.ViewData.Model;
			Assert.AreEqual("", alunoModel.NomeSocial);
			Assert.AreEqual(DateTime.Parse("02-02-2005"), alunoModel.DataNascimento);
			Assert.AreEqual("14588756499", alunoModel.Cpf);
			Assert.AreEqual("Praca General Joao Pereira", alunoModel.Rua);
			Assert.AreEqual("49500000", alunoModel.Cep);
			Assert.AreEqual("Itabaiana", alunoModel.Cidade);
			Assert.AreEqual("Escola Estadual Dr. Airton Teles", alunoModel.ProcedenciaEscolar);
			Assert.AreEqual("Brasileiro", alunoModel.Nacionalidade);
			Assert.AreEqual("23409809", alunoModel.Identidade);
			Assert.AreEqual("79999443234", alunoModel.Telefone);
			Assert.AreEqual("M", alunoModel.Sexo);
			Assert.AreEqual("54765409897765612344556098779809", alunoModel.CertidaoNascimento);
			Assert.AreEqual("Branco", alunoModel.CorRaca);
			Assert.AreEqual("234098788908721", alunoModel.Sus);
			Assert.AreEqual("22356599001", alunoModel.Nis);
			Assert.AreEqual("Centro", alunoModel.Bairro);
			Assert.AreEqual("Proximo a ZapLanches", alunoModel.Complemento);
			Assert.AreEqual("765", alunoModel.NumeroImovel);
			Assert.AreEqual("Mauricio Santos Santana", alunoModel.Nome);
		}

		[TestMethod()]
		public void EditTest_Get()
		{
			// Act
			var result = controller.Edit(GetTargetAlunoModel().IdAluno, GetTargetAlunoModel());

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
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AlunoModel));
			AlunoModel alunoModel = (AlunoModel)viewResult.ViewData.Model;
			Assert.AreEqual("", alunoModel.NomeSocial);
			Assert.AreEqual(DateTime.Parse("2005-02-02"), alunoModel.DataNascimento);
			Assert.AreEqual("14588756499", alunoModel.Cpf);
			Assert.AreEqual("Praca General Joao Pereira", alunoModel.Rua);
			Assert.AreEqual("49500000", alunoModel.Cep);
			Assert.AreEqual("Itabaiana", alunoModel.Cidade);
			Assert.AreEqual("Escola Estadual Dr. Airton Teles", alunoModel.ProcedenciaEscolar);
			Assert.AreEqual("Brasileiro", alunoModel.Nacionalidade);
			Assert.AreEqual("23409809", alunoModel.Identidade);
			Assert.AreEqual("79999443234", alunoModel.Telefone);
			Assert.AreEqual("M", alunoModel.Sexo);
			Assert.AreEqual("54765409897765612344556098779809", alunoModel.CertidaoNascimento);
			Assert.AreEqual("Branco", alunoModel.CorRaca);
			Assert.AreEqual("234098788908721", alunoModel.Sus);
			Assert.AreEqual("22356599001", alunoModel.Nis);
			Assert.AreEqual("Centro", alunoModel.Bairro);
			Assert.AreEqual("Proximo a ZapLanches", alunoModel.Complemento);
			Assert.AreEqual("765", alunoModel.NumeroImovel);
			Assert.AreEqual("Mauricio Santos Santana", alunoModel.Nome);
		}

		[TestMethod()]
		public void DeleteTest_Get()
		{
			// Act
			var result = controller.Delete(GetTargetAlunoModel().IdAluno, GetTargetAlunoModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static AlunoModel GetNewAluno()
		{
			return new AlunoModel
			{
				IdAluno = 4,
				NomeSocial = "",
				DataNascimento = DateTime.Parse("2001-04-20"),
				Cpf = "00321456798",
				Rua = "Praca General Joao Pereira",
				Cep = "49500000",
				Cidade = "Itabaiana",
				ProcedenciaEscolar = "Escola Estadual Dr. Airton Teles",
				Nacionalidade = "Brasileiro",
				Identidade = "22127769",
				Telefone = "79999698870",
				Sexo = "M",
				CertidaoNascimento = "51265433897709615644577098779809",
				CorRaca = "Branco",
				Sus = "222098888768721",
				Nis = "24156769886",
				Bairro = "Centro",
				Complemento = "",
				NumeroImovel = "4312",
				Nome = "José Vinicius Pereira",
			};

		}
		private static Aluno GetTargetAluno()
		{
			return new Aluno
			{
				IdAluno = 1,
				NomeSocial = "",
				DataNascimento = DateTime.Parse("2005-02-02"),
				Cpf = "14588756499",
				Rua = "Praca General Joao Pereira",
				Cep = "49500000",
				Cidade = "Itabaiana",
				ProcedenciaEscolar = "Escola Estadual Dr. Airton Teles",
				Nacionalidade = "Brasileiro",
				Identidade = "23409809",
				Telefone = "79999443234",
				Sexo = "M",
				CertidaoNascimento = "54765409897765612344556098779809",
				CorRaca = "Branco",
				Sus = "234098788908721",
				Nis = "22356599001",
				Bairro = "Centro",
				Complemento = "Proximo a ZapLanches",
				NumeroImovel = "765",
				Nome = "Mauricio Santos Santana",
			};
		}

	private static AlunoModel GetTargetAlunoModel()
	{
		return new AlunoModel
		{
			IdAluno = 2,
			NomeSocial = "Thays",
			DataNascimento = DateTime.Parse("2001-04-20"),
			Cpf = "33288756599",
			Rua = "Rua Francisco Oliveira",
			Cep = "49509088",
			Cidade = "Itabaiana",
			ProcedenciaEscolar = "Colegio Monteiro Lobato",
			Nacionalidade = "Brasileiro",
			Identidade = "12207604",
			Telefone = "79988905540",
			Sexo = "M",
			CertidaoNascimento = "54673309897711616044556098889803",
			CorRaca = "Negro",
			Sus = "113432998008712",
			Nis = "33277609002",
			Bairro = "Mamede Paes Mendonca",
			Complemento = "Proximo ao Pancadao",
			NumeroImovel = "4328",
			Nome = "Paulo Sergio Costa",
		};
	}

		private static IEnumerable<Aluno> GetTestAlunos()
		{
			return new List<Aluno>
			{
				new Aluno
				{
					IdAluno = 1,
					NomeSocial = "",
					DataNascimento = DateTime.Parse("2002-12-11"),
					Cpf = "22156899804",
					Rua = "Rua Leandro Maciel",
					Cep = "49500000",
					Cidade = "Itabaiana",
					ProcedenciaEscolar = "Escola Estadual Nestor Carvalho",
					Nacionalidade = "Brasileiro",
					Identidade = "21409802",
					Telefone = "79998894432",
					Sexo = "F",
					CertidaoNascimento = "54765409897765612344556098779809",
					CorRaca = "Branco",
					Sus = "211108768968741",
					Nis = "22346989221",
					Bairro = "Centro",
					Complemento = "Proximo a Mercearia Barreto",
					NumeroImovel = "445",
					Nome = "Ana Luiza Santana Assis",
				},
				new Aluno
				{
					IdAluno = 2,
					NomeSocial = "",
					DataNascimento = DateTime.Parse("2005-02-02"),
					Cpf = "14588756499",
					Rua = "Praca General Joao Pereira",
					Cep = "49500000",
					Cidade = "Itabaiana",
					ProcedenciaEscolar = "Escola Estadual Dr. Airton Teles",
					Nacionalidade = "Brasileiro",
					Identidade = "23409809",
					Telefone = "79999443234",
					Sexo = "M",
					CertidaoNascimento = "54765409897765612344556098779809",
					CorRaca = "Branco",
					Sus = "234098788908721",
					Nis = "22356599001",
					Bairro = "Centro",
					Complemento = "Proximo a ZapLanches",
					NumeroImovel = "765",
					Nome = "Mauricio Santos Santana",
				},
				new Aluno
				{
					IdAluno = 3,
					NomeSocial = "",
					DataNascimento = DateTime.Parse("2003-10-23"),
					Cpf = "03799259589",
					Rua = "Jose Sizino de Almeida",
					Cep = "49500000",
					Cidade = "Itabaiana",
					ProcedenciaEscolar = "Escola Estadual Dr. Airton Teles",
					Nacionalidade = "Brasileiro",
					Identidade = "25088106",
					Telefone = "79999250295",
					Sexo = "M",
					CertidaoNascimento = "33165409877764312244556598779809",
					CorRaca = "Pardo",
					Sus = "211098787708721",
					Nis = "456356546006",
					Bairro = "Centro",
					Complemento = "Proximo a Padaria Santa Terezinha",
					NumeroImovel = "3345",
					Nome = "Vinicius Santos Goes",
				},
			};
		}
	}
}