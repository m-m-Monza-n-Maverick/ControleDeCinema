using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloSessao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace ControleDeCinema.Infra.Orm.Compartilhado
{
	public class ControleDeCinemaDbContext : DbContext
	{
		public DbSet<Filme> Filmes { get; set; }
		public DbSet<Ingresso> Ingressos { get; set; }
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

				filmeBuilder.Property(f => f.Id)
					.IsRequired()
					.ValueGeneratedOnAdd();

				filmeBuilder.Property(f => f.Titulo)
					.IsRequired()
					.HasColumnType("varchar(200)");

				filmeBuilder.Property(f => f.Duracao)
					.IsRequired()
					.HasColumnType("time");

				filmeBuilder.Property(f => f.Genero)
					.IsRequired()
					.HasColumnType("varchar(200)");

				filmeBuilder.Property(f => f.ImageData)
					.IsRequired()
					.HasColumnType("varbinary(max)");

				filmeBuilder.Property(f => f.ImageContentType)
					.IsRequired()
					.HasMaxLength(255)
					.HasColumnType("nvarchar(255)");
			});

			modelBuilder.Entity<Ingresso>(ingressoBuilder =>
			{
				ingressoBuilder.ToTable("TBIngresso");

				ingressoBuilder.Property(i => i.Id)
					.IsRequired()
					.ValueGeneratedOnAdd();

				ingressoBuilder.Property(m => m.Meia)
					.IsRequired()
					.HasColumnType("bit");

				ingressoBuilder.Property(m => m.Valor)
					.IsRequired()
					.HasColumnType("decimal");

				ingressoBuilder.HasOne(p => p.Sessao)
					.WithMany()
					.HasForeignKey("Sessao_Id")
					.IsRequired()
					.OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Ignore<Sessao>();
		}
	}
}
