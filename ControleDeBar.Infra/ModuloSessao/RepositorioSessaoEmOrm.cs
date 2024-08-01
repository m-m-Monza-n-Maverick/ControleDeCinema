using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
namespace ControleDeBar.Infra.Orm.ModuloSessao;
public class RepositorioSessaoEmOrm : IRepositorioSessao
{
    ControleDeCinemaDbContext dbContext;
    public RepositorioSessaoEmOrm(ControleDeCinemaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    #region CRUD
    public void Inserir(Sessao registro)
    {
        dbContext.Sessoes.Add(registro);
        dbContext.SaveChanges();
    }
    public bool Editar(Sessao registroAtualizado)
    {
        if (registroAtualizado is null) return false;

        dbContext.Sessoes.Update(registroAtualizado);

        dbContext.SaveChanges();

        return true;
    }
    public bool Excluir(Sessao registro)
    {
        if (registro is null) return false;

        dbContext.Sessoes.Remove(registro);

        dbContext.SaveChanges();

        return true;
    }
    #endregion

    public List<Sessao> SelecionarTodos() => [.. dbContext.Sessoes];
    public Sessao SelecionarPorId(int id) => dbContext.Sessoes.Include(s => s.Filme).Include(s => s.Sala).FirstOrDefault(c => c.Id == id)!;
}