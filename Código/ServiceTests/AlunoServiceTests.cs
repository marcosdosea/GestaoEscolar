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
	public class AlunoServiceTests
	{
		private SiCAEContext _context;
		private IAlunoService _alunoService;

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
			var alunos = new List<Aluno>
				{
					new Aluno { IdAluno = 1, NomeSocial = "",
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
					Nome = "Mauricio Santos Santana"},

					new Aluno { IdAluno = 2, NomeSocial = "",
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
					Nome = "Ana Luiza Santana Assis"},

					new Aluno { IdAluno = 3, NomeSocial = "",
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
					Nome = "Vinicius Santos Goes"},
				};

			_context.AddRange(alunos);
			_context.SaveChanges();

			_alunoService = new AlunoService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_alunoService.Inserir(new Aluno() { IdAluno = 4,
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
			});
			// Assert
			Assert.AreEqual(4, _alunoService.ObterTodos().Count());
			var aluno = _alunoService.Obter(4);
			Assert.AreEqual("", aluno.NomeSocial);
			Assert.AreEqual(DateTime.Parse("2001-04-20"), aluno.DataNascimento);
			Assert.AreEqual("00321456798", aluno.Cpf);
			Assert.AreEqual("49500000", aluno.Cep);
			Assert.AreEqual("Itabaiana", aluno.Cidade);
			Assert.AreEqual("Escola Estadual Dr. Airton Teles", aluno.ProcedenciaEscolar);
			Assert.AreEqual("Brasileiro", aluno.Nacionalidade);
			Assert.AreEqual("22127769", aluno.Identidade);
			Assert.AreEqual("79999698870", aluno.Telefone);
			Assert.AreEqual("M", aluno.Sexo);
			Assert.AreEqual("51265433897709615644577098779809", aluno.CertidaoNascimento);
			Assert.AreEqual("Branco", aluno.CorRaca);
			Assert.AreEqual("222098888768721", aluno.Sus);
			Assert.AreEqual("24156769886", aluno.Nis);
			Assert.AreEqual("Centro", aluno.Bairro);
			Assert.AreEqual("", aluno.Complemento);
			Assert.AreEqual("4312", aluno.NumeroImovel);
			Assert.AreEqual("José Vinicius Pereira", aluno.Nome);
		}

		[TestMethod()]
		public void EditarTest()
		{
			var aluno = _alunoService.Obter(3);
			aluno.NomeSocial = "";
			aluno.DataNascimento = DateTime.Parse("2003-10-23");
			aluno.Cpf = "03799259589";
			aluno.Rua = "Jose Sizino de Almeida";
			aluno.Cep = "49500000";
			aluno.Cidade = "Itabaiana";
			aluno.ProcedenciaEscolar = "Escola Estadual Dr. Airton Teles";
			aluno.Nacionalidade = "Brasileiro";
			aluno.Identidade = "25088106";
			aluno.Telefone = "79999250295";
			aluno.Sexo = "M";
			aluno.CertidaoNascimento = "33165409877764312244556598779809";
			aluno.CorRaca = "Pardo";
			aluno.Sus = "211098787708721";
			aluno.Nis = "456356546006";
			aluno.Bairro = "Centro";
			aluno.Complemento = "Proximo a Padaria Santa Terezinha";
			aluno.NumeroImovel = "3345";
			aluno.Nome = "Vinicius Santos Goes";
			_alunoService.Editar(aluno);
			aluno = _alunoService.Obter(3);
			aluno.NomeSocial = "";
			aluno.DataNascimento = DateTime.Parse("2003-10-23");
			aluno.Cpf = "03799259589";
			aluno.Rua = "Jose Sizino de Almeida";
			aluno.Cep = "49500000";
			aluno.Cidade = "Itabaiana";
			aluno.ProcedenciaEscolar = "Escola Estadual Dr. Airton Teles";
			aluno.Nacionalidade = "Brasileiro";
			aluno.Identidade = "25088106";
			aluno.Telefone = "79999250295";
			aluno.Sexo = "M";
			aluno.CertidaoNascimento = "33165409877764312244556598779809";
			aluno.CorRaca = "Pardo";
			aluno.Sus = "211098787708721";
			aluno.Nis = "456356546006";
			aluno.Bairro = "Centro";
			aluno.Complemento = "Proximo a Padaria Santa Terezinha";
			aluno.NumeroImovel = "3345";
			aluno.Nome = "Vinicius Santos Goes";
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_alunoService.Remover(2);
			// Assert
			Assert.AreEqual(2, _alunoService.ObterTodos().Count());
			var aluno = _alunoService.Obter(2);
			Assert.AreEqual(null, aluno);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaAluno = _alunoService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaAluno, typeof(IEnumerable<Aluno>));
			Assert.IsNotNull(listaAluno);
			Assert.AreEqual(3, listaAluno.Count());
			Assert.AreEqual(1, listaAluno.First().IdAluno);
			Assert.AreEqual("Mauricio Santos Santana", listaAluno.First().Nome);
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
			var aluno = _alunoService.Obter(1);
			Assert.IsNotNull(aluno);
			Assert.AreEqual("", aluno.NomeSocial);
			Assert.AreEqual(DateTime.Parse("2005-02-02"), aluno.DataNascimento);
			Assert.AreEqual("14588756499", aluno.Cpf);
			Assert.AreEqual("Praca General Joao Pereira", aluno.Rua);
			Assert.AreEqual("49500000", aluno.Cep);
			Assert.AreEqual("Itabaiana", aluno.Cidade);
			Assert.AreEqual("Escola Estadual Dr. Airton Teles", aluno.ProcedenciaEscolar);
			Assert.AreEqual("Brasileiro", aluno.Nacionalidade);
			Assert.AreEqual("23409809", aluno.Identidade);
			Assert.AreEqual("79999443234", aluno.Telefone);
			Assert.AreEqual("M", aluno.Sexo);
			Assert.AreEqual("54765409897765612344556098779809", aluno.CertidaoNascimento);
			Assert.AreEqual("Branco", aluno.CorRaca);
			Assert.AreEqual("234098788908721", aluno.Sus);
			Assert.AreEqual("22356599001", aluno.Nis);
			Assert.AreEqual("Centro", aluno.Bairro);
			Assert.AreEqual("Proximo a ZapLanches", aluno.Complemento);
			Assert.AreEqual("765", aluno.NumeroImovel);
			Assert.AreEqual("Mauricio Santos Santana", aluno.Nome);
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
			var alunos = _alunoService.ObterPorNomeOrdenadoDescending("Mauricio");
			Assert.IsNotNull(alunos);
			Assert.AreEqual(3, alunos.Count());
			Assert.AreEqual("Vinicius Santos Goes", alunos.First().Nome);
		}
	}
}