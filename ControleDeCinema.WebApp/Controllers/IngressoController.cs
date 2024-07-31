using ControleDeBar.Infra.Orm.ModuloFilme;
using ControleDeBar.Infra.Orm.ModuloIngresso;
using ControleDeBar.Infra.Orm.ModuloSessao;
using ControleDeBar.WebApp.Models;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ControleDeCinema.WebApp.Controllers
{
	public class IngressoController : Controller
	{
        public Sessao Sessao { get; set; }

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
            if (filmeSelecionadoId <= 0)
            {
                ModelState.AddModelError("", "Nenhum filme foi selecionado.");
                return View("selecionarFilme");
            }

            var db = new ControleDeCinemaDbContext();
            var repositorioFilme = new RepositorioFilmeEmOrm(db);
            var repositorioSessao = new RepositorioSessaoEmOrm(db);
            var filme = repositorioFilme.SelecionarPorId(filmeSelecionadoId);
            var sala = new Sala(78);
            //ViewBag.Sessoes = repositorioSessao.SelecionarTodos().FindAll(s => s.Filme == filme);

            Sessao sessao = new(sala, DateTime.Now, filme)
            {
                Id = 1
            };

            Sessao sessao2 = new(sala, DateTime.Now, filme)
            {
                Id = 2
            };

            Sessao sessao3 = new(sala, DateTime.Now, filme)
            {
                Id = 3
            };

            List<Sessao> sessoes = [sessao, sessao2, sessao3];

            ViewBag.Sessoes = sessoes;
            ViewBag.Filme = filme;

            return View();
        }

        [HttpPost]
        public ViewResult SelecionarLugares(int sessaoSelecionadaId)
        {
            if (sessaoSelecionadaId <= 0)
            {
                ModelState.AddModelError("", "Nenhuma sessão foi selecionada.");
                return View("selecionarSessao");
            }

            var db = new ControleDeCinemaDbContext();
            var repositorioFilme = new RepositorioFilmeEmOrm(db);

            var repositorioSessao = new RepositorioSessaoEmOrm(db);
            var filme = repositorioFilme.SelecionarTodos();

            var sala = new Sala(78);

            Sessao sessao = new(sala, DateTime.Now, filme[0])
            {
                Id = sessaoSelecionadaId
            };

            Sessao = sessao;

            ViewBag.Sessao = sessao;

            return View();
        }

        [HttpPost]
        public ViewResult FinalizarCompra(string poltronasSelecionadas)
        {
            if (string.IsNullOrEmpty(poltronasSelecionadas))
            {
                ModelState.AddModelError("", "Nenhuma poltrona selecionada. Por favor, selecione pelo menos uma poltrona");
                return View("selecionarPoltronas");
            }

            ViewBag.Poltronas = poltronasSelecionadas.Split(',').ToList();

            return View();
        }

        [HttpPost]
        public ViewResult Concluir(string ingressos)
        {
            if (string.IsNullOrEmpty(ingressos))
            {
                ModelState.AddModelError("", "Nenhuma seleção de tipo de ingresso foi realizada");
                return View("SelecionarPoltronas");
            }

            var ingressosTipos = JsonConvert.DeserializeObject<List<bool>>(ingressos);

            var db = new ControleDeCinemaDbContext();
            var repositorioIngresso = new RepositorioIngressoEmOrm(db);

            foreach (bool meia in ingressosTipos)
            {
                var ingresso = new Ingresso(meia, 0, Sessao);
                repositorioIngresso.Inserir(ingresso);
            }

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
