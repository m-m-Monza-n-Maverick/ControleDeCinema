using ControleDeCinema.Dominio.ModuloSala;
namespace ControleDeCinema.Testes.Unidade.ModuloSala
{
    [TestClass]
    public class SalaTeste
    {
        [TestClass]
        [TestCategory("Testes de Unidade de Sala")]
        public class SalaTests
        {
            [TestMethod]
            public void Deve_Validar_Sala_Corretamente()
            {
                // Arrange (preparação do teste)
                Sala contaInvalida = new(0);

                List<string> errosEsperados =
                [
                    "\nO campo \"Capacidade\" é obrigatório. Tente novamente ",
                ];

                // Act (ação do teste)
                List<string> erros = contaInvalida.Validar();

                // Assert (asserção do teste)
                CollectionAssert.AreEqual(errosEsperados, erros);
            }
        }
    }
}