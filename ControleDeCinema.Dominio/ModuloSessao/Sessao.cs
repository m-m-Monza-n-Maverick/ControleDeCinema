using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
namespace ControleDeCinema.Dominio.ModuloSessao
{
    public class Sessao () : EntidadeBase
    {
        public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Filme Filme { get; set; }
        public decimal NumIngressosDisponiveis 
        {
            get
            {
                if (Sala is null) return 0;
                return Sala.Capacidade - poltronasOcupadas.Count;
            } 
            private set { } 
        }
        public bool Encerrada 
        { 
            get 
            {
                if (Filme is null) return false;
                if (DateTime.Now > Horario + Filme.Duracao) return true;
                return false;
            }
            private set { }
        }
        public List<string> poltronasOcupadas { get; set; }


        public Sessao(Sala sala, DateTime horario, Filme filme) : this ()
        {
            Sala = sala;
            Horario = horario;
            Filme = filme;
            poltronasOcupadas = [];
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
	        var registro = (Sessao)registroAtualizado;

	        Sala = registro.Sala;
            Horario = registro.Horario;
            Filme = registro.Filme;
        }
        public override List<string> Validar()
        {
	        List<string> erros = [];
	        /*	        VerificaNulo(ref erros, Titulo, "Título");
				        VerificaNulo(ref erros, Duracao, "Duração");
	        */
	        return erros;
        }
        public override string ToString() => $"Sessão às {Horario.ToShortTimeString()} para o filme \"{Filme}\"";
	}
}