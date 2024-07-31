using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
namespace ControleDeBar.Infra.Orm.ModuloIngresso;
public class RepositorioIngressoEmOrm(ControleDeCinemaDbContext dbContext) : IRepositorioIngresso
{
	ControleDeCinemaDbContext dbContext = dbContext;

	#region CRUD
	public void Inserir(Ingresso registro)
	{
		dbContext.Ingressos.Add(registro);
		dbContext.SaveChanges();
	}
	public bool Editar(Ingresso registroAtualizado)
	{
		if (registroAtualizado is null) return false;

		dbContext.Ingressos.Update(registroAtualizado);

		dbContext.SaveChanges();

		return true;
	}
	public bool Excluir(Ingresso registro)
	{
		if (registro is null) return false;

		dbContext.Ingressos.Remove(registro);

		dbContext.SaveChanges();

		return true;
	}
	#endregion

	public List<Ingresso> SelecionarTodos() => [.. dbContext.Ingressos];
	public Ingresso SelecionarPorId(int id) => dbContext.Ingressos.Include(c => c.Sessao).FirstOrDefault(c => c.Id == id)!;
}