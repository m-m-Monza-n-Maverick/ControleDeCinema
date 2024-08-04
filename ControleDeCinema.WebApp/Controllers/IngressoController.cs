using ControleDeBar.Infra.Orm.ModuloFilme;
using ControleDeBar.Infra.Orm.ModuloIngresso;
using ControleDeBar.Infra.Orm.ModuloSala;
using ControleDeBar.Infra.Orm.ModuloSessao;
using ControleDeBar.WebApp.Models;
using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace ControleDeCinema.WebApp.Controllers
{
	public class IngressoController : Controller
	{
        public ViewResult SelecionarFilme() 
		{ 
			var db = new ControleDeCinemaDbContext();
			var repositorioSessao = new RepositorioSessaoEmOrm(db);

            List<Filme> filmes = [];

            foreach(Sessao sessao in repositorioSessao.SelecionarTodos())
                if(!sessao.Encerrada)
                    filmes.Add(sessao.Filme);

            ViewBag.Filmes = filmes.Distinct().ToList();

			return View();
		}

        [HttpPost]
        public ViewResult SelecionarSessao(int filmeSelecionadoId)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioFilme = new RepositorioFilmeEmOrm(db);
            var repositorioSessao = new RepositorioSessaoEmOrm(db);
			var repositorioSala = new RepositorioSalaEmOrm(db);

			var filme = repositorioFilme.SelecionarPorId(filmeSelecionadoId);

            ViewBag.Sessoes = repositorioSessao.SelecionarTodos().FindAll(s => s.Filme == filme && !s.Encerrada);

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
                var ingresso = new Ingresso(meia, poltronas[i], sessao);
                repositorioIngresso.Inserir(ingresso);
                i++;
            }

            sessao.poltronasOcupadas.AddRange(poltronas);
            repositorioSessao.Editar(sessao);

            var mensagem = new MensagemViewModel()
            {
                Mensagem = $"Os ingressos foram comprados com sucesso!",
                LinkRedirecionamento = "/ingresso/selecionarFilme"
            };

            return View("mensagens", mensagem);
        }
    }
}
