using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.ModuloSessao;
namespace ControleDeCinema.Dominio.ModuloIngresso
{
    public class Ingresso() : EntidadeBase
    {
	    public bool Meia { get; set; }
        public decimal Valor { get; set; }
        public Sessao Sessao { get; set; }

        public Ingresso(bool meia, decimal valor, Sessao sessao) : this()
        {
            Meia = meia;
            Valor = valor;
            Sessao = sessao;
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
	        var registro = (Ingresso)registroAtualizado;

	        Meia = registro.Meia;
	        Valor = registro.Valor;
	        Sessao = registro.Sessao;
        }
        public override List<string> Validar()
        {
	        List<string> erros = [];
	        /*	        VerificaNulo(ref erros, Titulo, "Título");
				        VerificaNulo(ref erros, Duracao, "Duração");
	        */
	        return erros;
        }
        public override string ToString() => $"Ingresso para: {Sessao}";
    }
}