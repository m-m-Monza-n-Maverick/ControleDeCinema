using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using System.ComponentModel.DataAnnotations;
namespace ControleDeCinema.WebApp.Models
{
	public class ListarSessaoViewModel
	{
		public int Id { get; set; }
		public DateTime Horario { get; set; }
		public Filme Filme { get; set; }
		public Sala Sala { get; set; }
		public bool Encerrada { get; set; }
		public decimal NumIngressosDisponiveis { get; set; }
	}

    public class DetalhesSessaoViewModel
    {
        public int Id { get; set; }
        public DateTime Horario { get; set; }
        public Filme Filme { get; set; }
        public Sala Sala { get; set; }
    }

    public class InserirSessaoViewModel
	{
		[Required]
		public int SalaId { get; set; }

		[Required]
		public DateTime Horario { get; set; }

		[Required]
		public int FilmeId { get; set; }
	}

    public class EditarSessaoViewModel
    {
        public int Id { get; set; }

        [Required]
        public int SalaId { get; set; }

        [Required]
        public DateTime Horario { get; set; }

        [Required]
        public int FilmeId { get; set; }
    }

	public class ExcluirSessaoViewModel
	{
		public int Id { get; set; }
		public DateTime Horario { get; set; }
		public Filme Filme { get; set; }
		public Sala Sala { get; set; }
	}
}
