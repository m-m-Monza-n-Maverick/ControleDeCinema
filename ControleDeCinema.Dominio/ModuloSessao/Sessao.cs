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
        public decimal NumIngressos { get => Sala.AcentosDisponiveis; set{} }
        public bool Encerrada { get; set; }

        public Sessao(Sala sala, DateTime horario, Filme filme) : this ()
        {
            Sala = sala;
            Horario = horario;
            Filme = filme;
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