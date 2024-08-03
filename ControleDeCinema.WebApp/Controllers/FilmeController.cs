using ControleDeBar.Infra.Orm.ModuloFilme;
using ControleDeBar.WebApp.Models;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.AspNetCore.Mvc;
using ControleDeCinema.WebApp.Models;
namespace ControleDeCinema.WebApp.Controllers
{
	public class FilmeController : Controller
	{
		public ViewResult Listar()
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filmes = repositorioFilme.SelecionarTodos();

			var listarFilmesVm = filmes // mapeamento
				.Select(f =>
					new ListarFilmeViewModel
					{
						Id = f.Id,
						Titulo = f.Titulo,
						Duracao = f.Duracao,
						Genero = f.Genero
                    });

			return View(listarFilmesVm);
		}
		public ViewResult Detalhes(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(id);

			var detalhesFilmeVm = new DetalhesFilmeViewModel
			{
				Id = id,
				Titulo = filme.Titulo,
				Duracao = filme.Duracao,
				Genero = filme.Genero,
				ImageData = filme.ImageData,
				ImageContentType = filme.ImageContentType
			};

			return View(detalhesFilmeVm);
		}


		public ViewResult Inserir() => View();
		[HttpPost]
		public ViewResult Inserir(InserirFilmeViewModel inserirFilmeVm)
		{
			if (!ModelState.IsValid) return View(inserirFilmeVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var novoFilme = new Filme(inserirFilmeVm.Titulo, inserirFilmeVm.Duracao, inserirFilmeVm.Genero, inserirFilmeVm.Poster);

			repositorioFilme.Inserir(novoFilme);

			HttpContext.Response.StatusCode = 201;

			var mensagem = new MensagemViewModel()
			{
				Mensagem = $"O filme: \"{novoFilme}\" foi cadastrado com sucesso!",
				LinkRedirecionamento = "/filme/listar"
			};

			return View("mensagens", mensagem);
		}


		public ViewResult Editar(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(id);

			var editarFilmeVm = new EditarFilmeViewModel
			{
				Id = id,
				Titulo = filme.Titulo,
				Duracao = filme.Duracao,
				Genero = filme.Genero,
				ImageData = filme.ImageData,
				ImageContentType = filme.ImageContentType,
			};

			return View(editarFilmeVm);
		}
		[HttpPost]
		public ViewResult Editar(EditarFilmeViewModel editarFilmeVm)
		{
			if (!ModelState.IsValid) return View(editarFilmeVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filmeOriginal = repositorioFilme.SelecionarPorId(editarFilmeVm.Id);

			filmeOriginal.Titulo = editarFilmeVm.Titulo;
			filmeOriginal.Duracao = editarFilmeVm.Duracao;
			filmeOriginal.Genero = editarFilmeVm.Genero;

			repositorioFilme.Editar(filmeOriginal);

			var mensagem = new MensagemViewModel()
			{
				Mensagem = $"O filme: \"{filmeOriginal}\" foi editado com sucesso!",
				LinkRedirecionamento = "/filme/listar"
			};

			return View("mensagens", mensagem);
		}


		public ViewResult Excluir(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(id);

			var excluirFilmeVm = new ExcluirFilmeViewModel
			{
				Id = id,
				Titulo = filme.Titulo,
				Duracao = filme.Duracao,
				Genero = filme.Genero
			};

			return View(excluirFilmeVm);
		}
		[HttpPost, ActionName("excluir")]
		public ViewResult ExcluirConfirmado(ExcluirFilmeViewModel excluirFilmeVm)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(excluirFilmeVm.Id);

			repositorioFilme.Excluir(filme);

			var mensagem = new MensagemViewModel()
			{
				Mensagem = $"O filme: \"{filme}\" foi excluído com sucesso!",
				LinkRedirecionamento = "/filme/listar"
			};

			return View("mensagens", mensagem);
		}
    }
}
