using ControleDeCinema.Dominio.ModuloFilme;
using System.ComponentModel.DataAnnotations;
namespace ControleDeCinema.WebApp.Models
{
	public class ListarFilmeViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public TimeSpan Duracao { get; set; }
		public string Genero { get; set; }
	}

	public class InserirFilmeViewModel
	{
		[Required(ErrorMessage = "O título do filme é obrigatório")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "A duração do filme é obrigatória")]
		public TimeSpan Duracao { get; set; }

		[Required(ErrorMessage = "O gênero do filme é obrigatório")]
		public string Genero { get; set; }
	}

	public class EditarFilmeViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "O título do filme é obrigatório")]
		public string Titulo { get; set; }

		[Required(ErrorMessage = "A duração do filme é obrigatória")]
		public TimeSpan Duracao { get; set; }

		[Required(ErrorMessage = "O gênero do filme é obrigatório")]
		public string Genero { get; set; }
	}

	public class ExcluirFilmeViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public TimeSpan Duracao { get; set; }
		public string Genero { get; set; }
	}

	public class DetalhesFilmeViewModel
	{
		public int Id { get; set; }
		public string Titulo { get; set; }
		public TimeSpan Duracao { get; set; }
		public string Genero { get; set; }
	}
}
