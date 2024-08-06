using ControleDeBar.Infra.Orm.ModuloFilme;
using ControleDeBar.Infra.Orm.ModuloSala;
using ControleDeBar.Infra.Orm.ModuloSessao;
using ControleDeBar.WebApp.Models;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace ControleDeCinema.WebApp.Controllers
{
	public class SessaoController : Controller
	{
        public ViewResult Listar()
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioSessao = new RepositorioSessaoEmOrm(db);

			var sessoes = repositorioSessao.SelecionarTodos();

			sessoes = [.. sessoes.OrderBy(s => s.Horario)];
			sessoes = [.. sessoes.OrderBy(s => s.Encerrada)];

			ViewBag.Linha = sessoes.Find(s => s.Encerrada)!.Id;

			var listarSessaosVm = sessoes // mapeamento
				.Select(s =>
					new ListarSessaoViewModel
					{
						Id = s.Id,
						Horario = s.Horario,
						Filme = s.Filme,
						Sala = s.Sala,
						Encerrada = s.Encerrada,
						NumIngressosDisponiveis = s.NumIngressosDisponiveis,
					}
				);

			return View(listarSessaosVm);
		}
		public ViewResult Detalhes(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioSessao = new RepositorioSessaoEmOrm(db);

			var sessao = repositorioSessao.SelecionarPorId(id);

			var detalhesSessaoVm = new DetalhesSessaoViewModel
			{
				Id = id,
				Filme = sessao.Filme,
				Horario = sessao.Horario,
				Sala = sessao.Sala,
				poltronasOcupadas = sessao.poltronasOcupadas
			};

			return View(detalhesSessaoVm);
		}


		public ViewResult Inserir()
		{
            var db = new ControleDeCinemaDbContext();
            var repositorioFilme = new RepositorioFilmeEmOrm(db);
            var repositorioSala = new RepositorioSalaEmOrm(db);

            ViewBag.Salas = repositorioSala.SelecionarTodos();
            ViewBag.Filmes = repositorioFilme.SelecionarTodos();

            return View();
		}
		[HttpPost]
		public ViewResult Inserir(InserirSessaoViewModel inserirSessaoVm)
		{
			if (!ModelState.IsValid) return View(inserirSessaoVm);

			var db = new ControleDeCinemaDbContext();
			var repositorioSessao = new RepositorioSessaoEmOrm(db);
            var repositorioFilme = new RepositorioFilmeEmOrm(db);
            var repositorioSala = new RepositorioSalaEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(inserirSessaoVm.FilmeId);
            var sala = repositorioSala.SelecionarPorId(inserirSessaoVm.SalaId);

			sala.HorariosOcupados = [inserirSessaoVm.Horario, inserirSessaoVm.Horario + filme.Duracao];
			repositorioSala.Editar(sala);

            var novaSessao = new Sessao(sala, inserirSessaoVm.Horario, filme);

			repositorioSessao.Inserir(novaSessao);

			HttpContext.Response.StatusCode = 201;

			var mensagem = new MensagemViewModel()
			{
				Mensagem = $"A sessão das {novaSessao.Horario.ToShortTimeString()}h para o filme \"{novaSessao.Filme.Titulo}\" foi cadastrada com sucesso!",
				LinkRedirecionamento = "/sessao/listar"
			};

			return View("mensagens", mensagem);
		}


		public ViewResult Editar(int id)
		{
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);
            var repositorioFilme = new RepositorioFilmeEmOrm(db);
            var repositorioSala = new RepositorioSalaEmOrm(db);

            ViewBag.Filmes = repositorioFilme.SelecionarTodos();
            ViewBag.Salas = repositorioSala.SelecionarTodos();

            var sessao = repositorioSessao.SelecionarPorId(id);

            var editarSessaoVm = new EditarSessaoViewModel
			{
                Id = id,
                Horario = sessao.Horario,
                FilmeId = sessao.Filme.Id,
                SalaId = sessao.Sala.Id,
            };

			return View(editarSessaoVm);
		}
		[HttpPost]
		public ViewResult Editar(EditarSessaoViewModel editarSessaoVm)
		{
			if (!ModelState.IsValid) return View(editarSessaoVm);

            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);
            var repositorioFilme = new RepositorioFilmeEmOrm(db);
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var filme = repositorioFilme.SelecionarPorId(editarSessaoVm.FilmeId);
            var sala = repositorioSala.SelecionarPorId(editarSessaoVm.SalaId);

            var sessaoOriginal = repositorioSessao.SelecionarPorId(editarSessaoVm.Id);

			sessaoOriginal.Filme = filme;
			sessaoOriginal.Horario = editarSessaoVm.Horario;
			sessaoOriginal.Sala = sala;

			repositorioSessao.Editar(sessaoOriginal);

			var mensagem = new MensagemViewModel()
			{
                Mensagem = $"A sessão das {sessaoOriginal.Horario.ToShortTimeString()}h para o filme \"{sessaoOriginal.Filme.Titulo}\" foi editada com sucesso!",
                LinkRedirecionamento = "/sessao/listar"
			};

			return View("mensagens", mensagem);
		}


		public ViewResult Excluir(int id)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioSessao = new RepositorioSessaoEmOrm(db);

			var sessao = repositorioSessao.SelecionarPorId(id);

			var excluirSessaoVm = new ExcluirSessaoViewModel
			{
				Id = id,
				Sala = sessao.Sala,
				Horario = sessao.Horario,
				Filme = sessao.Filme
			};

			return View(excluirSessaoVm);
		}


		[HttpPost, ActionName("excluir")]
		public ViewResult ExcluirConfirmado(ExcluirSessaoViewModel excluirSessaoVm)
		{
			var db = new ControleDeCinemaDbContext();
			var repositorioSessao = new RepositorioSessaoEmOrm(db);

			var sessao = repositorioSessao.SelecionarPorId(excluirSessaoVm.Id);

			repositorioSessao.Excluir(sessao);

			var mensagem = new MensagemViewModel()
			{
				Mensagem = $"A sessão das {sessao.Horario.ToShortTimeString()}h para o filme \"{sessao.Filme.Titulo}\" foi excluída com sucesso!",
				LinkRedirecionamento = "/sessao/listar"
			};

			return View("mensagens", mensagem);
		}

	}
}
