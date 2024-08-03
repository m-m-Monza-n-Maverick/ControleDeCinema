using ControleDeBar.Infra.Orm.ModuloSala;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Text;
namespace ControleDeCinema.Testes.Integracao.ModuloSala
{
    [TestClass]
    [TestCategory("Testes de Integração de Sala")]
    public class RepositorioSalaEmOrmTests
    {
        RepositorioSalaEmOrm repositorioSala;
        ControleDeCinemaDbContext dbContext;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext = new();
            repositorioSala = new(dbContext);

            dbContext.Salas.RemoveRange(dbContext.Salas);
        }

        [TestMethod]
        public void Deve_Inserir_Sala_Corretamente()
        {
            // Arrange
            Sala novoSala = new(10);

            // act
            repositorioSala.Inserir(novoSala);

            // Assert
            Sala salaSelecionado = repositorioSala.SelecionarPorId(novoSala.Id);

            Assert.AreEqual(novoSala, salaSelecionado);
        }

        [TestMethod]
        public void Deve_Editar_Sala_Corretamente()
        {
            // Arrange
            Sala salaOriginal = new(10);

            repositorioSala.Inserir(salaOriginal);

            Sala salaParaAtualizacao = repositorioSala.SelecionarPorId(salaOriginal.Id);

            salaParaAtualizacao.Capacidade = 20;

            // Act
            repositorioSala.Editar(salaParaAtualizacao);

            // Assert
            Assert.AreEqual(salaOriginal, salaParaAtualizacao);
        }

        [TestMethod]
        public void Deve_Excluir_Sala_Corretamente()
        {
            // Arrange
            Sala sala = new(10);

            repositorioSala.Inserir(sala);

            // Act
            repositorioSala.Excluir(sala);

            // Assert
            Sala salaSelecionado = repositorioSala.SelecionarPorId(sala.Id);

            Assert.IsNull(salaSelecionado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Corretamente()
        {
            // Arrange
            List<Sala> salasParaInserir =
            [
                new(1),
                new(2),
                new(3)
            ];

            foreach (Sala sala in salasParaInserir)
                repositorioSala.Inserir(sala);

            // Act
            List<Sala> salasSelecionados = repositorioSala.SelecionarTodos();

            // Assert
            CollectionAssert.AreEqual(salasParaInserir, salasSelecionados);
        }
    }
}