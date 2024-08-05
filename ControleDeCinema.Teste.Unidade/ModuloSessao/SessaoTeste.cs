using ControleDeCinema.Dominio.ModuloSessao;
using Microsoft.AspNetCore.Http;
using System.Text;
namespace ControleDeCinema.Testes.Unidade.ModuloSessao
{
    [TestClass]
    public class SessaoTeste
    {
        [TestClass]
        [TestCategory("Testes de Unidade de Sessao")]
        public class SessaoTests
        {
            [TestMethod]
            public void Deve_Validar_Sessao_Corretamente()
            {
                // Arrange (prepara��o do teste)
                Sessao contaInvalida = new(null, DateTime.MinValue, null);

                List<string> errosEsperados =
                [
                    "\nO campo \"Sala\" � obrigat�rio. Tente novamente ",
                    "\nO campo \"Hor�rio\" � obrigat�rio. Tente novamente ",
                    "\nO campo \"Filme\" � obrigat�rio. Tente novamente ",
                ];

                // Act (a��o do teste)
                List<string> erros = contaInvalida.Validar();

                // Assert (asser��o do teste)
                CollectionAssert.AreEqual(errosEsperados, erros);
            }
        }
    }
}