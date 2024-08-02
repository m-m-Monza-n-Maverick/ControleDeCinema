using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeCinema.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class BDSessao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AcentosDisponiveis = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sessoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Horario = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FilmeId = table.Column<int>(type: "int", nullable: false),
                    NumIngressos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Encerrada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessoes_Sala_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Sala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sessoes_TBFilme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "TBFilme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_FilmeId",
                table: "Sessoes",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessoes_SalaId",
                table: "Sessoes",
                column: "SalaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessoes");

            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
