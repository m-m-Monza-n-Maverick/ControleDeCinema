﻿using ControleDeCinema.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace ControleDeCinema.Infra.Orm.Migrations
{
    [DbContext(typeof(ControleDeCinemaDbContext))]
    partial class ControleDeCinemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloFilme.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("Duracao")
                        .HasColumnType("time");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ImageContentType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TBFilme", (string)null);
                });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloIngresso.Ingresso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Meia")
                        .HasColumnType("bit");

                    b.Property<string>("Poltrona")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Sessao_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Sessao_Id");

                    b.ToTable("TBIngresso", (string)null);
                });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloSala.Sala", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<decimal>("Capacidade")
                    .HasColumnType("decimal(18,2)");

                b.Property<string>("HorariosOcupados")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("Ocupada")
                    .HasColumnType("bit");

                b.HasKey("Id");

                b.ToTable("TBSala", (string)null);
            });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloSessao.Sessao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Encerrada")
                        .HasColumnType("bit");

                    b.Property<int>("Filme_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NumIngressosDisponiveis")
                        .HasColumnType("decimal");

                    b.Property<int>("Sala_Id")
                        .HasColumnType("int");

                    b.Property<string>("poltronasOcupadas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Filme_Id");

                    b.HasIndex("Sala_Id");

                    b.ToTable("TBSessao", (string)null);
                });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloIngresso.Ingresso", b =>
                {
                    b.HasOne("ControleDeCinema.Dominio.ModuloSessao.Sessao", "Sessao")
                        .WithMany()
                        .HasForeignKey("Sessao_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Sessao");
                });

            modelBuilder.Entity("ControleDeCinema.Dominio.ModuloSessao.Sessao", b =>
                {
                    b.HasOne("ControleDeCinema.Dominio.ModuloFilme.Filme", "Filme")
                        .WithMany()
                        .HasForeignKey("Filme_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ControleDeCinema.Dominio.ModuloSala.Sala", "Sala")
                        .WithMany()
                        .HasForeignKey("Sala_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Filme");

                    b.Navigation("Sala");
                });
#pragma warning restore 612, 618
        }
    }
}
