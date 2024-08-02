using ControleDeCinema.Dominio.ModuloSessao;
namespace ControleDeCinema.WebApp.Models
{
    public class ListarIngressoViewModel
    {
        public int Id { get; set; }
        public bool Meia { get; set; }
        public string Poltrona { get; set; }
        public decimal Valor { get; set; }
        public Sessao Sessao { get; set; }
    }

    public class FinalizarCompraViewModel
    {
        public string PoltronasSelecionadas {  get; set; }
        public int SessaoId { get; set; }
    }

    public class ConcluirViewModel
    {
        public string Ingressos { get; set; }
        public int SessaoId { get; set; }
        public string Poltronas { get; set; }
    }
}
