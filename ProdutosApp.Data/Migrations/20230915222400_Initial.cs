using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutosApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DESCRICAO = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAULTIMAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ATIVO = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTO");
        }
    }
}
