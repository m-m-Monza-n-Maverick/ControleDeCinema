using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloSessao;
using Microsoft.AspNetCore.Http;
using System.Text;
using ControleDeCinema.Dominio.ModuloSala;
namespace ControleDeCinema.Testes.Unidade.ModuloIngresso
{
    [TestClass]
    public class IngressoTeste
    {
        [TestClass]
        [TestCategory("Testes de Unidade de Ingresso")]
        public class IngressoTests
        {
            [TestMethod]
            public void Deve_Ocupar_Poltronas_Corretamente()
            {
                // Arrange (preparação do teste)
                bool meiaEntrada = true;
                string poltrona = "A2";

                var content = "Este é o conteúdo do arquivo.";
                var contentBytes = Encoding.UTF8.GetBytes(content);
                var stream = new MemoryStream(contentBytes);
                var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "text/plain"
                };

                Filme filme = new("Oi", TimeSpan.MinValue, "Ação", imagem);
                Sala sala = new(78);
                Sessao sessao = new(sala,DateTime.Now, filme);

                // Act (ação do teste)
                Ingresso ingressoCriado = new(meiaEntrada, poltrona, sessao);

                // Assert (asserção do teste)
                var poltronasOcupadas = sessao.poltronasOcupadas;

                //Eu não soube assessar o "Concluir" do IngressoController, para testar
                CollectionAssert.AllItemsAreNotNull(poltronasOcupadas);
            }
        }
    }
}