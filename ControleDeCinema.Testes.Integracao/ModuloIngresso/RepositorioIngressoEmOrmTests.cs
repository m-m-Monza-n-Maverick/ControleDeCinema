using ControleDeBar.Infra.Orm.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Text;
namespace ControleDeCinema.Testes.Integracao.ModuloIngresso
{
    [TestClass]
    [TestCategory("Testes de Integração de Ingresso")]
    public class RepositorioIngressoEmOrmTests
    {
        RepositorioIngressoEmOrm repositorioIngresso;
        ControleDeCinemaDbContext dbContext;

        [TestInitialize]
        public void ConfigurarTestes()
        {
            dbContext = new();
            repositorioIngresso = new(dbContext);

            dbContext.Ingressos.RemoveRange(dbContext.Ingressos);
        }

        [TestMethod]
        public void Deve_Inserir_Ingresso_Corretamente()
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

            Ingresso novoIngresso = new(true, "A8", sessao);

            // act
            repositorioIngresso.Inserir(novoIngresso);

            // Assert
            Ingresso ingressoSelecionado = repositorioIngresso.SelecionarPorId(novoIngresso.Id);

            Assert.AreEqual(novoIngresso, ingressoSelecionado);
        }
    }
}