using ControleDeBar.Infra.Orm.ModuloSessao;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Text;
namespace ControleDeCinema.Testes.Integracao.ModuloSessao
{
    [TestClass]
    [TestCategory("Testes de Integração de Sessao")]
    public class RepositorioSessaoEmOrmTests
    {
        RepositorioSessaoEmOrm repositorioSessao;
        ControleDeCinemaDbContext dbContext;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext = new();
            repositorioSessao = new(dbContext);

            dbContext.Sessoes.RemoveRange(dbContext.Sessoes);
        }

        [TestMethod]
        public void Deve_Inserir_Sessao_Corretamente()
        {
            // Arrange
            var content = "Este é o conteúdo do arquivo.";
            var contentBytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(contentBytes);
            var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            Filme filme = new("Oi", new TimeSpan(0, 0, 30), "Ação", imagem);
            Sala sala = new(78);

            Sessao novaSessao = new(sala, DateTime.Now, filme);

            // act
            repositorioSessao.Inserir(novaSessao);

            // Assert
            Sessao sessaoSelecionado = repositorioSessao.SelecionarPorId(novaSessao.Id);

            Assert.AreEqual(novaSessao, sessaoSelecionado);
        }

        [TestMethod]
        public void Deve_Editar_Sessao_Corretamente()
        {
            // Arrange
            var content = "Este é o conteúdo do arquivo.";
            var contentBytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(contentBytes);
            var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

			Filme filme = new("Oi", new TimeSpan(0, 0, 30), "Ação", imagem);
			Sala sala = new(78);
            Sala sala2 = new(80);

			Sessao sessaoOriginal = new(sala, DateTime.Now, filme);

			repositorioSessao.Inserir(sessaoOriginal);

            Sessao sessaoParaAtualizacao = repositorioSessao.SelecionarPorId(sessaoOriginal.Id);

            sessaoParaAtualizacao.Sala = sala2;

            // Act
            repositorioSessao.Editar(sessaoParaAtualizacao);

            // Assert
            Assert.AreEqual(sessaoOriginal, sessaoParaAtualizacao);
        }

        [TestMethod]
        public void Deve_Excluir_Sessao_Corretamente()
        {
            // Arrange
            var content = "Este é o conteúdo do arquivo.";
            var contentBytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(contentBytes);
            var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

			Filme filme = new("Oi", new TimeSpan(0, 0, 30), "Ação", imagem);
			Sala sala = new(78);

			Sessao sessao = new(sala, DateTime.Now, filme);

            repositorioSessao.Inserir(sessao);

            // Act
            repositorioSessao.Excluir(sessao);

            // Assert
            Sessao sessaoSelecionado = repositorioSessao.SelecionarPorId(sessao.Id);

            Assert.IsNull(sessaoSelecionado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Corretamente()
        {
            // Arrange
            var content = "Este é o conteúdo do arquivo.";
            var contentBytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(contentBytes);
            var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

			Filme filme = new("Oi", new TimeSpan(0, 0, 30), "Ação", imagem);
			Sala sala = new(78);

			List<Sessao> sessoesParaInserir =
            [
				new(sala, DateTime.Now, filme),
				new(sala, DateTime.Now, filme),
				new(sala, DateTime.Now, filme)
			];

            foreach (Sessao sessao in sessoesParaInserir)
                repositorioSessao.Inserir(sessao);

            // Act
            List<Sessao> sessaosSelecionados = repositorioSessao.SelecionarTodos();

            // Assert
            CollectionAssert.AreEqual(sessoesParaInserir, sessaosSelecionados);
        }
    }
}