using ControleDeCinema.Dominio.ModuloSessao;
namespace ControleDeCinema.WebApp.Models
{
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
