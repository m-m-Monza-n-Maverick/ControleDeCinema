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
                // Arrange (prepara��o do teste)
                Sala contaInvalida = new(0);

                List<string> errosEsperados =
                [
                    "\nO campo \"Capacidade\" � obrigat�rio. Tente novamente ",
                ];

                // Act (a��o do teste)
                List<string> erros = contaInvalida.Validar();

                // Assert (asser��o do teste)
                CollectionAssert.AreEqual(errosEsperados, erros);
            }
        }
    }
}