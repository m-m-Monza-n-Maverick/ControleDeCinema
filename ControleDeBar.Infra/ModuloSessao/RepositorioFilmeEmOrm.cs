using ControleDeCinema.Dominio.ModuloSessao;
using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
namespace ControleDeBar.Infra.Orm.ModuloSessao;
public class RepositorioSessaoEmOrm : RepositorioBaseEmOrm<Sessao>, IRepositorioSessao
{
	ControleDeCinemaDbContext dbContext;

    public RepositorioSessaoEmOrm(ControleDeCinemaDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Sessao> ObterRegistros() => dbContext.Sessoes;
	public override Sessao SelecionarPorId(int id) => dbContext.Sessoes.Find(id)!;
}