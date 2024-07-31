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
		[Required]
		public string Titulo { get; set; }

		[Required]
		public TimeSpan Duracao { get; set; }

		[Required]
		public string Genero { get; set; }

		[Required]
        public IFormFile Poster { get; set; }
    }

	public class EditarFilmeViewModel
	{
		public int Id { get; set; }

		[Required]
		public string Titulo { get; set; }

		[Required]
		public TimeSpan Duracao { get; set; }

		[Required]
		public string Genero { get; set; }

		public byte[] ImageData { get; set; }
		public string ImageContentType { get; set; }
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
        public byte[] ImageData { get; set; }
        public string ImageContentType { get; set; }
    }
}
