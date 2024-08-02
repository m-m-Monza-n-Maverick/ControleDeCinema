using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeCinema.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class BancoDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBFilmes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    Duracao = table.Column<TimeSpan>(type: "time", nullable: false),
                    Genero = table.Column<string>(type: "varchar(200)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ImageContentType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFilmes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBSala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidade = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBSala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBSessao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sala_Id = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Filme_Id = table.Column<int>(type: "int", nullable: false),
                    NumIngressos = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Encerrada = table.Column<bool>(type: "bit", nullable: false),
                    poltronasOcupadas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBSessao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBSessao_TBFilmes_Filme_Id",
                        column: x => x.Filme_Id,
                        principalTable: "TBFilmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBSessao_TBSala_Sala_Id",
                        column: x => x.Sala_Id,
                        principalTable: "TBSala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBIngressos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meia = table.Column<bool>(type: "bit", nullable: false),
                    Poltrona = table.Column<string>(type: "varchar(10)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sessao_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBIngressos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBIngressos_TBSessao_Sessao_Id",
                        column: x => x.Sessao_Id,
                        principalTable: "TBSessao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBIngressos_Sessao_Id",
                table: "TBIngressos",
                column: "Sessao_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBSessao_Filmes_Id",
                table: "TBSessao",
                column: "Filme_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBSessao_Sala_Id",
                table: "TBSessao",
                column: "Sala_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBIngressos");

            migrationBuilder.DropTable(
                name: "TBSessao");

            migrationBuilder.DropTable(
                name: "TBFilmes");

            migrationBuilder.DropTable(
                name: "TBSala");
        }
    }
}
