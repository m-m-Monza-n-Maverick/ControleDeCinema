using ControleDeCinema.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
namespace ControleDeCinema.Infra.Orm.Compartilhado;
public abstract class RepositorioBaseEmOrm<TEntidade> where TEntidade : EntidadeBase
{
    protected readonly ControleDeCinemaDbContext dbContext;

    public RepositorioBaseEmOrm(ControleDeCinemaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    protected abstract DbSet<TEntidade> ObterRegistros();

    #region CRUD
    public void Inserir(TEntidade registro)
    {
        ObterRegistros().Add(registro);

        dbContext.SaveChanges();
    }
    public virtual bool Editar(TEntidade registroOriginal, TEntidade registroAtualizado)
    {
        if (registroOriginal == null || registroAtualizado == null)
            return false;

        registroAtualizado.Atualizar(registroOriginal);

        ObterRegistros().Update(registroOriginal);

        dbContext.SaveChanges();

        return true;
    }
    public virtual bool Editar(TEntidade registroAtualizado)
    {
        if (registroAtualizado == null)
            return false;

        ObterRegistros().Update(registroAtualizado);

        dbContext.SaveChanges();

        return true;
    }
    public virtual bool Excluir(TEntidade registro)
    {
        if (registro is null) return false;

        ObterRegistros().Remove(registro);

        dbContext.SaveChanges();

        return true;
    }
    #endregion

	public virtual TEntidade SelecionarPorId(int id)
	    => ObterRegistros()
	            .FirstOrDefault(m => m.Id == id)!;
    public virtual List<TEntidade> SelecionarTodos()
	    => [.. ObterRegistros()];
}