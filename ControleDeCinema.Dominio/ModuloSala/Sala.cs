using ControleDeCinema.Dominio.Compartilhado;
namespace ControleDeCinema.Dominio.ModuloSala
{
    public class Sala() : EntidadeBase
    {
        public decimal Capacidade { get; set; }
        public decimal AcentosDisponiveis { get; set; }

        public Sala(decimal capacidade) : this()
        {
            Capacidade = capacidade;
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
	        var registro = (Sala)registroAtualizado;

	        Capacidade = registro.Capacidade;
            AcentosDisponiveis = registro.AcentosDisponiveis;
        }
		public override List<string> Validar()
		{
			List<string> erros = [];
			/*	        VerificaNulo(ref erros, Titulo, "Título");
						VerificaNulo(ref erros, Duracao, "Duração");
			*/
			return erros;
		}
		public override string ToString() => $"Sala [Id: {Id}]";
	}
}