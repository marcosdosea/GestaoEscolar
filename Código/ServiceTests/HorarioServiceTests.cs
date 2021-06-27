using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
	[TestClass()]
	public class HorarioServiceTests
	{
		private SiCAEContext _context;
		private IHorarioService _horarioService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<SiCAEContext>();
			builder.UseInMemoryDatabase("SiCAE");
			var options = builder.Options;

			_context = new SiCAEContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var diahoras = new List<Diahora>
				{
					new Diahora { IdDiaHora = 1, HorarioInicio = TimeSpan.Parse("12:00"), HorarioTermino = TimeSpan.Parse("12:00"), DiaSemana = "SEG"},
					new Diahora { IdDiaHora = 2, HorarioInicio = TimeSpan.Parse("9:00"), HorarioTermino = TimeSpan.Parse("10:50"), DiaSemana = "TER"},
					new Diahora { IdDiaHora = 3, HorarioInicio = TimeSpan.Parse("10:00"), HorarioTermino = TimeSpan.Parse("11:50"), DiaSemana = "QUA"},
				};

			_context.AddRange(diahoras);
			_context.SaveChanges();

			_horarioService = new HorarioService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_horarioService.Inserir(new Diahora() { IdDiaHora = 4, HorarioInicio = TimeSpan.Parse("07:00"), HorarioTermino = TimeSpan.Parse("08:50"), DiaSemana = "QUI" });
			// Assert
			Assert.AreEqual(4, _horarioService.ObterTodos().Count());
			var diahora = _horarioService.Obter(4);
			Assert.AreEqual(TimeSpan.Parse("07:00"), diahora.HorarioInicio);
			Assert.AreEqual(TimeSpan.Parse("08:50"), diahora.HorarioTermino);
			Assert.AreEqual("QUI", diahora.DiaSemana);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var diahora = _horarioService.Obter(3);
			diahora.DiaSemana = "QUA";
			diahora.HorarioInicio = TimeSpan.Parse("10:00");
			diahora.HorarioTermino = TimeSpan.Parse("11:50");
			_horarioService.Editar(diahora);
			diahora = _horarioService.Obter(3);
			diahora.DiaSemana = "QUA";
			diahora.HorarioInicio = TimeSpan.Parse("10:00");
			diahora.HorarioTermino = TimeSpan.Parse("11:50");
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_horarioService.Remover(2);
			// Assert
			Assert.AreEqual(2, _horarioService.ObterTodos().Count());
			var diahora = _horarioService.Obter(2);
			Assert.AreEqual(null, diahora);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaDiahora = _horarioService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaDiahora, typeof(IEnumerable<Diahora>));
			Assert.IsNotNull(listaDiahora);
			Assert.AreEqual(3, listaDiahora.Count());
			Assert.AreEqual(1, listaDiahora.First().IdDiaHora);
			Assert.AreEqual("SEG", listaDiahora.First().DiaSemana);
		}

		//[TestMethod()]
		//public void ObterTodosOrdenadoPorNomeTest()
		//{
			//var listaDiahora = _horarioService.ObterTodosOrdenadoPorNome();
			//Assert.IsInstanceOfType(listaDiahora, typeof(IEnumerable<Diahora>));
			//Assert.IsNotNull(listaDiahora);
			//Assert.AreNotEqual(0, listaDiahora.Count());
			//Assert.AreEqual(3, listaDiahora.First().IdDiahora);
			//Assert.AreEqual("Gleford Myers", listaDiahora.First().Nome);
		//}

		[TestMethod()]
		public void ObterTest()
		{
			var diahora = _horarioService.Obter(1);
			Assert.IsNotNull(diahora);
			Assert.AreEqual("SEG", diahora.DiaSemana);
		}

		//[TestMethod()]
		//public void ObterPorNomeTest()
		//{
		//	var diahoras = _diahoraService.ObterPorNome("Machado");
		//	Assert.IsNotNull(diahoras);
		//	Assert.AreEqual(1, diahoras.Count());
		//	Assert.AreEqual("Machado de Assis", diahoras.First().Nome);
		//}

		//[TestMethod()]
		//public void ObterPorNomeContendoTest()
		//{
			//var diahoras = _horarioService.ObterPorNomeContendo("Sommervile");
			//Assert.IsNotNull(diahoras);
			//Assert.AreEqual(1, diahoras.Count());
			//Assert.AreEqual("Ian S. Sommervile", diahoras.First().Nome);
		//}

		[TestMethod()]
		public void ObterPorNomeOrdenadoDescendingTest()
		{
			var diahoras = _horarioService.ObterPorNomeOrdenadoDescending("SEG");
			Assert.IsNotNull(diahoras);
			Assert.AreEqual(1, diahoras.Count());
			Assert.AreEqual("SEG", diahoras.First().DiaSemana);
		}
	}
}