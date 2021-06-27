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
    public class DisciplinaServiceTests
    {
        private SiCAEContext _context;
        private IDisciplinaService _disciplinaService;

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
            var disciplinas = new List<Disciplina>
                {
                    new Disciplina { IdDisciplina = 1, Nome = "Matemática" },
                    new Disciplina { IdDisciplina = 2, Nome = "Português" },
                    new Disciplina  { IdDisciplina = 3, Nome = "Biologia" },
                    new Disciplina  {  IdDisciplina = 4, Nome = "Geografia" }
                };

            _context.AddRange(disciplinas);
            _context.SaveChanges();

            _disciplinaService = new DisciplinaService(_context);
        }


        [TestMethod()]
        public void InserirTest()
        {
            // Act
            _disciplinaService.Inserir(new Disciplina() { IdDisciplina = 5, Nome = "Inglês" });
            // Assert
            Assert.AreEqual(5, _disciplinaService.ObterTodos().Count());
            var disciplina = _disciplinaService.Obter(5);
            Assert.AreEqual("Inglês", disciplina.Nome);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var disciplina = _disciplinaService.Obter(3);
            disciplina.Nome = "Biologia";
            _disciplinaService.Editar(disciplina);
            disciplina = _disciplinaService.Obter(3);
            Assert.AreEqual("Biologia", disciplina.Nome);
        }

        [TestMethod()]
        public void RemoverTest()
        {
            // Act
            _disciplinaService.Remover(2);
            // Assert
            Assert.AreEqual(3, _disciplinaService.ObterTodos().Count());
            var disciplina = _disciplinaService.Obter(2);
            Assert.AreEqual(null, disciplina);
        }

        [TestMethod()]
        public void ObterTodosTest()
        {
            // Act
            var listaDisciplina = _disciplinaService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaDisciplina, typeof(IEnumerable<Disciplina>));
            Assert.IsNotNull(listaDisciplina);
            Assert.AreEqual(4, listaDisciplina.Count());
            Assert.AreEqual(1, listaDisciplina.First().IdDisciplina);
            Assert.AreEqual("Matemática", listaDisciplina.First().Nome);
        }

        [TestMethod()]
        public void ObterTest()
        {
            var disciplina = _disciplinaService.Obter(1);
            Assert.IsNotNull(disciplina);
            Assert.AreEqual("Matemática", disciplina.Nome);
        }

        [TestMethod()]
        public void ObterPorNomeTest()
        {
            var disciplinas = _disciplinaService.ObterPorNome("Matemática");
            Assert.IsNotNull(disciplinas);
            Assert.AreEqual(1, disciplinas.Count());
            Assert.AreEqual("Matemática", disciplinas.First().Nome);
        }
    }
}