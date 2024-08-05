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
                // Arrange (preparação do teste)
                Sessao contaInvalida = new(null, DateTime.MinValue, null);

                List<string> errosEsperados =
                [
                    "\nO campo \"Sala\" é obrigatório. Tente novamente ",
                    "\nO campo \"Horário\" é obrigatório. Tente novamente ",
                    "\nO campo \"Filme\" é obrigatório. Tente novamente ",
                ];

                // Act (ação do teste)
                List<string> erros = contaInvalida.Validar();

                // Assert (asserção do teste)
                CollectionAssert.AreEqual(errosEsperados, erros);
            }
        }
    }
}