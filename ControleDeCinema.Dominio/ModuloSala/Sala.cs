using ControleDeCinema.Dominio.Compartilhado;
namespace ControleDeCinema.Dominio.ModuloSala
{
    public class Sala() : EntidadeBase
    {
        public decimal Capacidade { get; set; }
        public List<DateTime> HorariosOcupados { get; set; }
		public bool Ocupada
		{
			get 
			{
				if (HorariosOcupados.Count != 0)
				{
					if (DateTime.Now >= HorariosOcupados[0] && DateTime.Now <= HorariosOcupados[1]) return true;

					if (DateTime.Now > HorariosOcupados[1])
						HorariosOcupados.Clear();
				}

				return false;
			}			
			private set { }		
		}

		public Sala(decimal capacidade) : this()
		{
			Capacidade = capacidade;
			HorariosOcupados = [];
		}

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
	        var registro = (Sala)registroAtualizado;

	        Capacidade = registro.Capacidade;
        }
		public override List<string> Validar()
		{
			List<string> erros = [];

			VerificaNulo(ref erros, Capacidade, "Capacidade");
			return erros;
		}
		public override string ToString() => $"Sala {Id}";
	}
}