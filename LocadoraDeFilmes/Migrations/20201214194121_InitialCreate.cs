using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocadoraDeFilmes.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    CPF = table.Column<string>(maxLength: 11, nullable: false),
                    DataDeNasc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFilme",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 100, nullable: false),
                    ClassificacaoIndicativa = table.Column<int>(nullable: false),
                    Lancamento = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFilme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLocacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    IdFilme = table.Column<int>(nullable: false),
                    DataLocaccao = table.Column<DateTime>(nullable: false),
                    DataDevolucao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocacao", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCliente");

            migrationBuilder.DropTable(
                name: "tblFilme");

            migrationBuilder.DropTable(
                name: "tblLocacao");
        }
    }
}
