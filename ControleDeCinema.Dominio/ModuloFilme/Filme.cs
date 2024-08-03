using ControleDeCinema.Dominio.Compartilhado;
using ControleDeCinema.Dominio.Compartilhado.Extensions;
using Microsoft.AspNetCore.Http;
namespace ControleDeCinema.Dominio.ModuloFilme
{
    public class Filme() : EntidadeBase
    {
		public string Titulo { get; set; }
		public TimeSpan Duracao { get; set; }
		public string Genero { get; set; }

		// Propriedade para armazenar a imagem como byte[]
		public byte[] ImageData { get; set; }

		// Propriedade para armazenar o tipo de conteúdo da imagem (ex: "image/png")
		public string ImageContentType { get; set; }

        public Filme(string titulo, TimeSpan duracao, string genero, IFormFile image) : this()
        {
            Titulo = titulo.ToTitleCase();
            Duracao = duracao;
            Genero = genero;
            ImageData = image != null ? ConvertImageToByteArray(image) : null!;
            ImageContentType = image != null ? image.ContentType : null!;
        }

        private byte[] ConvertImageToByteArray(IFormFile image)
		{
			if (image == null || image.Length == 0)
			{
				throw new ArgumentNullException(nameof(image), "A imagem não pode ser nula ou vazia");
			}

			using var memoryStream = new MemoryStream();
			image.CopyTo(memoryStream);
			return memoryStream.ToArray();
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
			VerificaNulo(ref erros, Titulo, "Título");
			VerificaNulo(ref erros, Duracao, "Duração");
            VerificaNulo(ref erros, Genero, "Gênero");
            VerificaNulo(ref erros, ImageData, "Pôster");

            return erros;
        }
        public override string ToString() => Titulo;

        protected void VerificaNulo(ref List<string> erros, byte[] campoTestado, string mostraCampo)
        {
            if (campoTestado is null)
                erros.Add($"\nO campo \"{mostraCampo}\" é obrigatório. Tente novamente ");
        }
    }
}