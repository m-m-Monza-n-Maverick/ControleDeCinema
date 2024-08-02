using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
namespace ControleDeBar.Infra.Orm.ModuloIngresso;
public class RepositorioIngressoEmOrm(ControleDeCinemaDbContext dbContext)
{
	ControleDeCinemaDbContext dbContext = dbContext;

	public void Inserir(Ingresso registro)
	{
		dbContext.Ingressos.Add(registro);
		dbContext.SaveChanges();
	}
    public Ingresso SelecionarPorId(int id) => dbContext.Ingressos.Include(i => i.Sessao).FirstOrDefault(i => i.Id == id)!;
}