using ControleDeBar.Infra.Orm.ModuloSessao;
using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCinema.WebApp.Controllers
{
    public class SessaoController : Controller
    {

        public ViewResult Listar()
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessoes = repositorioSessao.SelecionarTodos();

            var listarSessoesVm = sessoes.Select(s =>
            {
                return new ListarSessaoViewModel
                {
                    Id = s.Id,
                    Sala = s.Sala,
                    Filme = s.Filme,
                    Horario = s.Horario,
                    NumIngressos = s.NumIngressos
                };
            });

            return View(listarSessoesVm);
        }


        public ViewResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Inserir(InserirSessaoViewModel SessaoVM)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db); ;

            var sessao = new Sessao(SessaoVM.Sala, SessaoVM.Horario, SessaoVM.Filme);
           
            repositorioSessao.Inserir(sessao);

            HttpContext.Response.StatusCode = 201;

            
            ViewBag.Mensagem = $"O registro com o ID {sessao.Id} foi cadastrado com sucesso!";
            ViewBag.Link = "/sessao/listar";

            return View("mensagens");
        }

        public ViewResult Editar(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessao = repositorioSessao.SelecionarPorId(id);

            var editarSessaoVm = new EditarSessaoViewModel()
            {
	            Id = id,
	            Filme = sessao.Filme,
	            Horario = sessao.Horario,
	            Sala = sessao.Sala,
	            NumIngressos = sessao.NumIngressos
            };

            return View(); ;
        }

        [HttpPost]
        public ViewResult Editar(EditarSessaoViewModel SessaoVM)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessaoOriginal = repositorioSessao.SelecionarPorId(SessaoVM.Id);

            sessaoOriginal.Filme = SessaoVM.Filme;
            sessaoOriginal.Horario = SessaoVM.Horario;
            sessaoOriginal.Sala = SessaoVM.Sala;

            repositorioSessao.Editar(sessaoOriginal);

            ViewBag.Mensagem = $"O registro com o ID {sessaoOriginal.Id} foi editado com sucesso!";
            ViewBag.Link = "/sessao/listar";

            return View("mensagens");
        }

        public ViewResult Excluir(int id)
        {
            var db = new ControleDeCinemaDbContext(); ;
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessao = repositorioSessao.SelecionarPorId(id);

            var excluirSessaoVM = new ExcluirSessaoViewModel()
            {
	            Filme = sessao.Filme,
	            Horario = sessao.Horario,
                Sala = sessao.Sala,
            };

            return View();
        }

        [HttpPost]
        public ViewResult ExcluirConfirmado(ExcluirSessaoViewModel sessaoVm)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSessao = new RepositorioSessaoEmOrm(db);

            var sessao = repositorioSessao.SelecionarPorId(sessaoVm.Id);

            repositorioSessao.Excluir(sessao);

            ViewBag.Mensagem = $"O registro com o ID {sessao.Id} foi excluído com sucesso!";
            ViewBag.Link = "/sessao/listar";

            return View("mensagens");
        }

        public ViewResult Detalhes(int id)
        {
            ControleDeCinemaDbContext db = new();
            IRepositorioSessao repositorioSessao = new RepositorioSessaoEmOrm(db);

            Sessao sessao = repositorioSessao.SelecionarPorId(id);

            var detalhesSessaoVm = new DetalhesSessaoViewModel()
            {
	            Id = sessao.Id,
                Filme = sessao.Filme,
                Horario = sessao.Horario,
                Sala = sessao.Sala,
                NumIngressos = sessao.NumIngressos,
                Encerrada = sessao.Encerrada ? "Encerrada" : "Aberta"
            };

            return View();
        }
    }
}
