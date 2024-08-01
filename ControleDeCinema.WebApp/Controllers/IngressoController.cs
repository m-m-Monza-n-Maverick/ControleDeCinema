using ControleDeBar.Infra.Orm.ModuloFilme;
using ControleDeBar.Infra.Orm.ModuloIngresso;
using ControleDeBar.Infra.Orm.ModuloSessao;
using ControleDeBar.WebApp.Models;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
namespace ControleDeCinema.WebApp.Controllers
{
	public class IngressoController : Controller
	{
		public ViewResult SelecionarFilme() 
		{ 
			var db = new ControleDeCinemaDbContext();
			var repositorioFilme = new RepositorioFilmeEmOrm(db);

			ViewBag.Filmes = repositorioFilme.SelecionarTodos();

			return View();
		}

        [HttpPost]
        public ViewResult SelecionarSessao(int filmeSelecionadoId)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioFilme = new RepositorioFilmeEmOrm(db);
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var filme = repositorioFilme.SelecionarPorId(filmeSelecionadoId);
            var sala = new Sala(78);
            var sala1 = new Sala(30);

            var sessao = new Sessao(sala, DateTime.Now, filme);
            var sessao1 = new Sessao(sala1, DateTime.Now, filme);

            repositorioSessao.Inserir(sessao);
            repositorioSessao.Inserir(sessao1);

            ViewBag.Sessoes = repositorioSessao.SelecionarTodos().FindAll(s => s.Filme == filme);

            return View();
        }

        [HttpPost]
        public ViewResult SelecionarLugares(int sessaoSelecionadaId)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            ViewBag.Sessao = repositorioSessao.SelecionarPorId(sessaoSelecionadaId);

            return View();
        }

        [HttpPost]
        public ViewResult FinalizarCompra(FinalizarCompraViewModel finalizarCompraVm)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessao = repositorioSessao.SelecionarPorId(finalizarCompraVm.SessaoId);

            ViewBag.Poltronas = finalizarCompraVm.PoltronasSelecionadas.Split(',').ToList();
            ViewBag.Sessao = sessao;

            return View();
        }

        [HttpPost]
        public ViewResult Concluir(ConcluirViewModel concluirVm)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioIngresso = new RepositorioIngressoEmOrm(db);
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var ingressosTipos = JsonConvert.DeserializeObject<List<bool>>(concluirVm.Ingressos);
            var sessao = repositorioSessao.SelecionarPorId(concluirVm.SessaoId);
            var poltronas = concluirVm.Poltronas.Split(',').ToList();
            var i = 0;

            foreach (bool meia in ingressosTipos)
            {
                var ingresso = new Ingresso(meia, poltronas[i], 0, sessao);
                repositorioIngresso.Inserir(ingresso);
                i++;
            }

            sessao.poltronasOcupadas.AddRange(poltronas);
            repositorioSessao.Editar(sessao);

            var mensagem = new MensagemViewModel()
            {
                Mensagem = $"Os ingressos foram comprados com sucesso!",
                LinkRedirecionamento = "/ingresso/listar"
            };

            return View("mensagens", mensagem);
        }

        /*
                public ViewResult Vender() => View();
                [HttpPost]
                public ViewResult Vender(InserirIngressoViewModel inserirIngressoVm)
                {
                    if (!ModelState.IsValid) return View(inserirIngressoVm);

                    var db = new ControleDeCinemaDbContext();
                    var repositorioIngresso = new RepositorioIngressoEmOrm(db);

                    var novoIngresso = new Ingresso(inserirIngressoVm.Titulo, inserirIngressoVm.Duracao, inserirIngressoVm.Genero);

                    repositorioIngresso.Inserir(novoIngresso);

                    HttpContext.Response.StatusCode = 201;

                    var mensagem = new MensagemViewModel()
                    {
                        Mensagem = $"O filme: \"{novoIngresso}\" foi cadastrado com sucesso!",
                        LinkRedirecionamento = "/filme/listar"
                    };

                    return View("mensagens", mensagem);
                }


                public ViewResult Editar(int id)
                {
                    var db = new ControleDeCinemaDbContext();
                    var repositorioIngresso = new RepositorioIngressoEmOrm(db);

                    var filme = repositorioIngresso.SelecionarPorId(id);

                    var editarIngressoVm = new EditarIngressoViewModel
                    {
                        Id = id,
                        Titulo = filme.Titulo,
                        Duracao = filme.Duracao,
                        Genero = filme.Genero
                    };

                    return View(editarIngressoVm);
                }
                [HttpPost]
                public ViewResult Editar(EditarIngressoViewModel editarIngressoVm)
                {
                    if (!ModelState.IsValid) return View(editarIngressoVm);

                    var db = new ControleDeCinemaDbContext();
                    var repositorioIngresso = new RepositorioIngressoEmOrm(db);

                    var filmeOriginal = repositorioIngresso.SelecionarPorId(editarIngressoVm.Id);

                    filmeOriginal.Titulo = editarIngressoVm.Titulo;
                    filmeOriginal.Duracao = editarIngressoVm.Duracao;
                    filmeOriginal.Genero = editarIngressoVm.Genero;

                    repositorioIngresso.Editar(filmeOriginal);

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
                    var repositorioIngresso = new RepositorioIngressoEmOrm(db);

                    var filme = repositorioIngresso.SelecionarPorId(id);

                    var excluirIngressoVm = new ExcluirIngressoViewModel
                    {
                        Id = id,
                        Titulo = filme.Titulo,
                        Duracao = filme.Duracao,
                        Genero = filme.Genero
                    };

                    return View(excluirIngressoVm);
                }
                [HttpPost, ActionName("excluir")]
                public ViewResult ExcluirConfirmado(ExcluirIngressoViewModel excluirIngressoVm)
                {
                    var db = new ControleDeCinemaDbContext();
                    var repositorioIngresso = new RepositorioIngressoEmOrm(db);

                    var filme = repositorioIngresso.SelecionarPorId(excluirIngressoVm.Id);

                    repositorioIngresso.Excluir(filme);

                    var mensagem = new MensagemViewModel()
                    {
                        Mensagem = $"O filme: \"{filme}\" foi excluído com sucesso!",
                        LinkRedirecionamento = "/filme/listar"
                    };

                    return View("mensagens", mensagem);
                }*/

    }
}
