using ControleDeCinema.Dominio.ModuloFilme;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Text;
namespace ControleDeCinema.Testes.Unidade.ModuloFilme
{
    [TestClass]
    public class FilmeTeste
    {
        [TestClass]
        [TestCategory("Testes de Unidade de Filme")]
        public class FilmeTests
        {
            [TestMethod]
            public void Deve_Validar_Filme_Corretamente()
            {
                // Arrange (prepara��o do teste)
                Filme contaInvalida = new("", TimeSpan.Zero, "", null);

                List<string> errosEsperados =
                [
                    "\nO campo \"T�tulo\" � obrigat�rio. Tente novamente ",
                    "\nO campo \"Dura��o\" � obrigat�rio. Tente novamente ",
                    "\nO campo \"G�nero\" � obrigat�rio. Tente novamente ",
                    "\nO campo \"P�ster\" � obrigat�rio. Tente novamente "
                ];

                // Act (a��o do teste)
                List<string> erros = contaInvalida.Validar();

                // Assert (asser��o do teste)
                CollectionAssert.AreEqual(errosEsperados, erros);
            }

            [TestMethod]
            public void Deve_Utilizar_Imagem_Corretamente()
            {
                // Arrange
                string titulo = "Oi";
                string genero = "A��o";
                TimeSpan duracao = new(0, 0, 0, 20);

                var content = "Este � o conte�do do arquivo.";
                var contentBytes = Encoding.UTF8.GetBytes(content);
                var stream = new MemoryStream(contentBytes);
                var imagem = new FormFile(stream, 0, stream.Length, "file", "example.txt")
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "text/plain"
                };

                // Act
                Filme filmeCriado = new (titulo, duracao, genero, imagem);

                // Assert

                Assert.IsTrue(filmeCriado.ImageData.Length != 0);
                Assert.IsNotNull(filmeCriado.ImageContentType);
            }
        }
    }
}