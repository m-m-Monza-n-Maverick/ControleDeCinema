using ControleDeCinema.Dominio.ModuloFilme;
using ControleDeCinema.Dominio.ModuloIngresso;
using ControleDeCinema.Dominio.ModuloSala;
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
        public DbSet<Sessao> Salas { get; set; }

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

                ingressoBuilder.Property(m => m.Poltrona)
					.IsRequired()
					.HasColumnType("varchar(10)");

                ingressoBuilder.Property(m => m.Valor)
					.IsRequired()
					.HasColumnType("decimal");

				ingressoBuilder.HasOne(p => p.Sessao)
					.WithMany()
					.HasForeignKey("Sessao_Id")
					.IsRequired()
					.OnDelete(DeleteBehavior.Restrict);
			});

            modelBuilder.Entity<Sessao>(sessaoBuilder =>
            {
                sessaoBuilder.ToTable("TBSessao");

                sessaoBuilder.Property(s => s.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                sessaoBuilder.Property(s => s.Horario)
                    .IsRequired()
                    .HasColumnType("datetime2");

                sessaoBuilder.Property(s => s.NumIngressos)
                    .IsRequired()
                    .HasColumnType("decimal");

                sessaoBuilder.Property(s => s.Encerrada)
					.IsRequired()
					.HasColumnType("bit");

                sessaoBuilder.Property(s => s.poltronasOcupadas)
                  .HasConversion(
                      v => string.Join(',', v),
                      v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
                  .HasColumnType("nvarchar(max)");

                sessaoBuilder.HasOne(s => s.Sala)
                    .WithMany()
                    .HasForeignKey("Sala_Id")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

				sessaoBuilder.HasOne(s => s.Filme)
                    .WithMany()
                    .HasForeignKey("Filme_Id")
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);
            });

			modelBuilder.Entity<Sala>(salaBuilder =>
			{
                salaBuilder.Property(s => s.Capacidade)
					.IsRequired()
					.HasColumnType("decimal");
            });
        }
	}
}
