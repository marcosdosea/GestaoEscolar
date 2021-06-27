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
    public class CidadeServiceTests
    {
        private SiCAEContext _context;
        private ICidadeService _cidadeService;

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
            var cidades = new List<Cidade>
            {
                new Cidade { idCidade = 1, CodIbge = 2802908, Nome = "Itabaiana" },
                new Cidade { idCidade = 2, CodIbge = 2805406, Nome = "Poço Redondo" },
                new Cidade { idCidade = 3, CodIbge = 2803203, Nome = "Itaporanga d'Ajuda" },
                new Cidade { idCidade = 4, CodIbge = 2801207, Nome = "Canindé de São Francisco" },
            };

            _context.AddRange(cidades);
            _context.SaveChanges();

            _cidadeService = new CidadeService(_context);
        }


        [TestMethod()]
        public void InserirTest()
        {
            // Act
            _cidadeService.Inserir(new Cidade() { idCidade = 5, CodIbge = 2802304, Nome = "Frei Paulo" });
            // Assert
            Assert.AreEqual(5, _cidadeService.ObterTodos().Count());
            var cidade = _cidadeService.Obter(5);
            Assert.AreEqual("Frei Paulo", cidade.Nome);
            Assert.AreEqual(2802304, cidade.CodIbge);
        }

        [TestMethod()]
        public void EditarTest()
        {
            var cidade = _cidadeService.Obter(3);
            cidade.Nome = "Itaporanga d'Ajuda";
            _cidadeService.Editar(cidade);
            cidade = _cidadeService.Obter(3);
            Assert.AreEqual("Itaporanga d'Ajuda", cidade.Nome);
            Assert.AreEqual(2803203, cidade.CodIbge);
        }

        [TestMethod()]
        public void RemoverTest()
        {
            // Act
            _cidadeService.Remover(2);
            // Assert
            Assert.AreEqual(3, _cidadeService.ObterTodos().Count());
            var cidade = _cidadeService.Obter(2);
            Assert.AreEqual(null, cidade);
        }

        [TestMethod()]
        public void ObterTodosTest()
        {
            // Act
            var listaCidade = _cidadeService.ObterTodos();
            // Assert
            Assert.IsInstanceOfType(listaCidade, typeof(IEnumerable<Cidade>));
            Assert.IsNotNull(listaCidade);
            Assert.AreEqual(4, listaCidade.Count());
            Assert.AreEqual(1, listaCidade.First().idCidade);
            Assert.AreEqual("Itabaiana", listaCidade.First().Nome);
        }

        [TestMethod()]
        public void ObterTest()
        {
            var cidade = _cidadeService.Obter(1);
            Assert.IsNotNull(cidade);
            Assert.AreEqual("Itabaiana", cidade.Nome);
        }

        [TestMethod()]
        public void ObterPorNomeTest()
        {
            var cidades = _cidadeService.ObterPorNome("Itabaiana");
            Assert.IsNotNull(cidades);
            Assert.AreEqual(1, cidades.Count());
            Assert.AreEqual("Itabaiana", cidades.First().Nome);
        }
    }
}