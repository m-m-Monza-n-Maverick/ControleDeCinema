using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Infra.Orm.Compartilhado;
namespace ControleDeBar.Infra.Orm.ModuloSala;
public class RepositorioSalaEmOrm : IRepositorioSala
{
	ControleDeCinemaDbContext dbContext;
	public RepositorioSalaEmOrm(ControleDeCinemaDbContext dbContext)
	{
		this.dbContext = dbContext;
	}

	#region CRUD
	public void Inserir(Sala registro)
	{
		dbContext.Salas.Add(registro);
		dbContext.SaveChanges();
	}
	public bool Editar(Sala registroAtualizado)
	{
		if (registroAtualizado is null) return false;

		dbContext.Salas.Update(registroAtualizado);

		dbContext.SaveChanges();

		return true;
	}
	public bool Excluir(Sala registro)
	{
		if (registro is null) return false;

		dbContext.Salas.Remove(registro);

		dbContext.SaveChanges();

		return true;
	}
	#endregion

	public List<Sala> SelecionarTodos() => [.. dbContext.Salas];
	public Sala SelecionarPorId(int id) => dbContext.Salas.Find(id)!;
}