using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.Compartilhado.Extensions;
namespace ControleDeCinema.Dominio.ModuloFilme
{
    public class Filme() : EntidadeBase
    {
        public string Titulo { get; set; }
        public TimeSpan Duracao { get; set; }
        public string Genero { get; set; }

		public Filme(string titulo, TimeSpan duracao, string genero) : this()
        {
	        Titulo = titulo.ToTitleCase();
            Duracao = duracao;
            Genero = genero;
        }

        public override void Atualizar(EntidadeBase registroAtualizado)
        {
	        var registro = (Filme)registroAtualizado;

            Titulo = registro.Titulo;
            Duracao = registro.Duracao;
            Genero = registro.Genero;
        }
        public override List<string> Validar()
        {
	        List<string> erros = [];
/*	        VerificaNulo(ref erros, Titulo, "Título");
	        VerificaNulo(ref erros, Duracao, "Duração");
*/
	        return erros;
        }
        public override string ToString() => Titulo;
    }
}