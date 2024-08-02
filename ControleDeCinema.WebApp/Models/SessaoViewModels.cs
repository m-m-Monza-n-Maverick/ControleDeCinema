using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;

namespace ControleDeCinema.WebApp.Models
{
	public class ListarSessaoViewModel
	{
        public int Id { get; set; }
        public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Filme Filme { get; set; }
        public decimal NumIngressos { get => Sala.AcentosDisponiveis; set { } }
        public string Encerrada { get; set; }
    }

	public class InserirSessaoViewModel
	{
		public int Id { get; set; }
		public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Filme Filme { get; set; }
        public decimal NumIngressos { get => Sala.AcentosDisponiveis; set { } }
        public bool Encerrada { get; set; }
    }
	public class EditarSessaoViewModel
	{
		public int Id { get; set; }
		public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Filme Filme { get; set; }
        public decimal NumIngressos { get => Sala.AcentosDisponiveis; set { } }
        public bool Encerrada { get; set; }
    }
	public class ExcluirSessaoViewModel
	{
		public int Id { get; set; }
		public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Filme Filme { get; set; }
        public decimal NumIngressos { get => Sala.AcentosDisponiveis; set { } }
        public bool Encerrada { get; set; }
    }
	public class DetalhesSessaoViewModel
	{
		public int Id { get; set; }
		public Sala Sala { get; set; }
        public DateTime Horario { get; set; }
        public Filme Filme { get; set; }
        public decimal NumIngressos { get => Sala.AcentosDisponiveis; set { } }
        public string Encerrada { get; set; }
    }
}
