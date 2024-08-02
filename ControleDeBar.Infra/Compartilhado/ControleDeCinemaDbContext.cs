using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloSala;
using ControleDeCinema.Dominio.ModuloSessao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace ControleDeCinema.Infra.Orm.Compartilhado
{
	public class ControleDeCinemaDbContext : DbContext
	{
		public DbSet<Filme> Filmes { get; set; }
		public DbSet<Sessao> Sessoes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var connectionString = config.GetConnectionString("SqlServer")!;

			optionsBuilder.UseSqlServer(connectionString);

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Filme>(filmeBuilder =>
			{
				filmeBuilder.ToTable("TBFilme");

				filmeBuilder.Property(m => m.Id)
					.IsRequired()
					.ValueGeneratedOnAdd();

				filmeBuilder.Property(m => m.Titulo)
					.IsRequired()
					.HasColumnType("varchar(200)");

				filmeBuilder.Property(m => m.Duracao)
					.IsRequired()
					.HasColumnType("time");

				filmeBuilder.Property(m => m.Genero)
					.IsRequired()
					.HasColumnType("varchar(200)");
				//.HasConversion<string>();
			});
		}
	}
}
