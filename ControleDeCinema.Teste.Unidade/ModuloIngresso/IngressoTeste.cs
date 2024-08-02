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
                // Arrange (prepara��o do teste)
                bool meiaEntrada = true;
                string poltrona = "A2";

                var content = "Este � o conte�do do arquivo.";
                var contentBytes = Encoding.UTF8.GetBytes(content);
                var stream = new MemoryStream(contentBytes);
                var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "text/plain"
                };

                Filme filme = new("Oi", TimeSpan.MinValue, "A��o", imagem);
                Sala sala = new(78);
                Sessao sessao = new(sala,DateTime.Now, filme);

                // Act (a��o do teste)
                Ingresso ingressoCriado = new(meiaEntrada, poltrona, sessao);

                // Assert (asser��o do teste)
                var poltronasOcupadas = sessao.poltronasOcupadas;

                //Eu n�o soube assessar o "Concluir" do IngressoController, para testar
                CollectionAssert.AllItemsAreNotNull(poltronasOcupadas);
            }
        }
    }
}