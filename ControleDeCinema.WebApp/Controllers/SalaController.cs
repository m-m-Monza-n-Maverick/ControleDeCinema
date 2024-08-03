using ControleDeBar.Infra.Orm.ModuloSala;
using ControleDeBar.WebApp.Models;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace ControleDeCinema.WebApp.Controllers
{
	public class SalaController : Controller
	{
        public ViewResult Listar()
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var salas = repositorioSala.SelecionarTodos();

            var listarSalasVm = salas // mapeamento
                .Select(s =>
                    new ListarSalaViewModel
                    {
                        Id = s.Id,
                        Capacidade = s.Capacidade
                    });

            return View(listarSalasVm);
        }
        public ViewResult Detalhes(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var sala = repositorioSala.SelecionarPorId(id);

            var detalhesSalaVm = new DetalhesSalaViewModel
            {
                Id = id,
                Capacidade = sala.Capacidade
            };

            return View(detalhesSalaVm);
        }


        public ViewResult Inserir() => View();
        [HttpPost]
        public ViewResult Inserir(InserirSalaViewModel inserirSalaVm)
        {
            if (!ModelState.IsValid) return View(inserirSalaVm);

            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var novaSala = new Sala(inserirSalaVm.Capacidade);

            repositorioSala.Inserir(novaSala);

            HttpContext.Response.StatusCode = 201;

            var mensagem = new MensagemViewModel()
            {
                Mensagem = $"A \"{novaSala}\" foi cadastrada com sucesso!",
                LinkRedirecionamento = "/sala/listar"
            };

            return View("mensagens", mensagem);
        }


        public ViewResult Editar(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var sala = repositorioSala.SelecionarPorId(id);

            var editarSalaVm = new EditarSalaViewModel
            {
                Id = id,
                Capacidade = sala.Capacidade
            };

            return View(editarSalaVm);
        }
        [HttpPost]
        public ViewResult Editar(EditarSalaViewModel editarSalaVm)
        {
            if (!ModelState.IsValid) return View(editarSalaVm);

            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var salaOriginal = repositorioSala.SelecionarPorId(editarSalaVm.Id);

            salaOriginal.Capacidade = editarSalaVm.Capacidade;

            repositorioSala.Editar(salaOriginal);

            var mensagem = new MensagemViewModel()
            {
                Mensagem = $"A \"{salaOriginal}\" foi editada com sucesso!",
                LinkRedirecionamento = "/sala/listar"
            };

            return View("mensagens", mensagem);
        }


        public ViewResult Excluir(int id)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var sala = repositorioSala.SelecionarPorId(id);

            var excluirSalaVm = new ExcluirSalaViewModel
            {
                Id = id,
                Capacidade = sala.Capacidade
            };

            return View(excluirSalaVm);
        }
        [HttpPost, ActionName("excluir")]
        public ViewResult ExcluirConfirmado(ExcluirSalaViewModel excluirSalaVm)
        {
            var db = new ControleDeCinemaDbContext();
            var repositorioSala = new RepositorioSalaEmOrm(db);

            var sala = repositorioSala.SelecionarPorId(excluirSalaVm.Id);

            repositorioSala.Excluir(sala);

            var mensagem = new MensagemViewModel()
            {
                Mensagem = $"A \"{sala}\" foi excluída com sucesso!",
                LinkRedirecionamento = "/sala/listar"
            };

            return View("mensagens", mensagem);
        }
    }
}
