using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.AspNetCore.Http;
namespace ControleDeBar.Infra.Orm.ModuloFilme;
public class RepositorioFilmeEmOrm : IRepositorioFilme
{
	ControleDeCinemaDbContext dbContext;
	public RepositorioFilmeEmOrm(ControleDeCinemaDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	#region CRUD
	public void Inserir(Filme registro)
	{
		dbContext.Filmes.Add(registro);
		dbContext.SaveChanges();
	}
	public bool Editar(Filme registroAtualizado)
	{
		if (registroAtualizado is null) return false;

		dbContext.Filmes.Update(registroAtualizado);

		dbContext.SaveChanges();

		return true;
	}
	public bool Excluir(Filme registro)
	{
		if (registro is null) return false;

		dbContext.Filmes.Remove(registro);

		dbContext.SaveChanges();

		return true;
	}
	#endregion

	public List<Filme> SelecionarTodos() => [.. dbContext.Filmes];
	public Filme SelecionarPorId(int id) => dbContext.Filmes.Find(id)!;
}