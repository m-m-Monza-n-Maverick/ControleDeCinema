using ControleDeBar.Infra.Orm.ModuloFilme;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Text;
namespace ControleDeCinema.Testes.Integracao.ModuloFilme
{
    [TestClass]
    [TestCategory("Testes de Integra��o de Filme")]
    public class RepositorioFilmeEmOrmTests
    {
        RepositorioFilmeEmOrm repositorioFilme;
        ControleDeCinemaDbContext dbContext;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext = new();
            repositorioFilme = new(dbContext);

            dbContext.Filmes.RemoveRange(dbContext.Filmes);
        }

        [TestMethod]
        public void Deve_Inserir_Filme_Corretamente()
        {
            // Arrange
            var content = "Este � o conte�do do arquivo.";
            var contentBytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(contentBytes);
            var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            Filme novoFilme = new("Oi", new TimeSpan(0, 0, 30), "A��o", imagem);

            // act
            repositorioFilme.Inserir(novoFilme);

            // Assert
            Filme filmeSelecionado = repositorioFilme.SelecionarPorId(novoFilme.Id);

            Assert.AreEqual(novoFilme, filmeSelecionado);
        }

        [TestMethod]
        public void Deve_Editar_Filme_Corretamente()
        {
            // Arrange
            var content = "Este � o conte�do do arquivo.";
            var contentBytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(contentBytes);
            var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            Filme filmeOriginal = new("Oi", new TimeSpan(0,0,30), "A��o", imagem);

            repositorioFilme.Inserir(filmeOriginal);

            Filme filmeParaAtualizacao = repositorioFilme.SelecionarPorId(filmeOriginal.Id);

            filmeParaAtualizacao.Titulo = "Testando";

            // Act
            repositorioFilme.Editar(filmeParaAtualizacao);

            // Assert
            Assert.AreEqual(filmeOriginal, filmeParaAtualizacao);
        }

        [TestMethod]
        public void Deve_Excluir_Filme_Corretamente()
        {
            // Arrange
            var content = "Este � o conte�do do arquivo.";
            var contentBytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(contentBytes);
            var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            Filme filme = new("Oi", new TimeSpan(0, 0, 30), "A��o", imagem);

            repositorioFilme.Inserir(filme);

            // Act
            repositorioFilme.Excluir(filme);

            // Assert
            Filme filmeSelecionado = repositorioFilme.SelecionarPorId(filme.Id);

            Assert.IsNull(filmeSelecionado);
        }

        [TestMethod]
        public void Deve_Selecionar_Todos_Corretamente()
        {
            // Arrange
            var content = "Este � o conte�do do arquivo.";
            var contentBytes = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(contentBytes);
            var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            };

            List<Filme> filmesParaInserir =
            [
                new("Oi", new TimeSpan(0,0,30), "A��o", imagem),
                new("Tchau", new TimeSpan(0,0,30), "A��o", imagem),
                new("Tudo bem?", new TimeSpan(0,0,30), "A��o", imagem)
            ];

            foreach (Filme filme in filmesParaInserir)
                repositorioFilme.Inserir(filme);

            // Act
            List<Filme> filmesSelecionados = repositorioFilme.SelecionarTodos();

            // Assert
            CollectionAssert.AreEqual(filmesParaInserir, filmesSelecionados);
        }
    }
}