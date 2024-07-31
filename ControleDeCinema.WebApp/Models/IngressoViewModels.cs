using System.ComponentModel.DataAnnotations;
namespace ControleDeCinema.WebApp.Models
{
    public class SelecionarFilmeViewModel
    {
        [Required]
        public int filmeSelecionadoId { get; set; }
    }
}
