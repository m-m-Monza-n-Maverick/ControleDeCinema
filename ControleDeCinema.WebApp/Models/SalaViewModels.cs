using System.ComponentModel.DataAnnotations;

namespace ControleDeCinema.WebApp.Models
{
    public class ListarSalaViewModel
    {
        public int Id { get; set; }
        public decimal Capacidade { get; set; }
    }

    public class InserirSalaViewModel
    {
        [Required]
        public decimal Capacidade { get; set; }
    }

    public class EditarSalaViewModel
    {
        public int Id { get; set; }

        [Required]
        public decimal Capacidade { get; set; }
    }

    public class ExcluirSalaViewModel
    {
        public int Id { get; set; }
        public decimal Capacidade { get; set; }
    }

    public class DetalhesSalaViewModel
    {
        public int Id { get; set; }
        public decimal Capacidade { get; set; }
    }
}
