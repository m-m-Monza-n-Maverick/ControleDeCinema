using ControleDeCinema.Dominio.ModuloSessao;
namespace ControleDeCinema.Dominio.ModuloIngresso
{
    public class Ingresso()
    {
        public int Id { get; set; }
	    public bool Meia { get; set; }
        public string Poltrona { get; set; }
        public decimal Valor { get; set; }
        public Sessao Sessao { get; set; }

        public Ingresso(bool meia, string poltrona, Sessao sessao) : this()
        {
            Meia = meia;
            Poltrona = poltrona;
            Sessao = sessao;
        }
    }
}