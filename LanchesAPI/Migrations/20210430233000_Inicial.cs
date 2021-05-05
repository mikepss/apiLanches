using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesAPI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ingredientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    preco = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredientes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lanches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanches", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "adicionais",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    idLanche = table.Column<int>(type: "int", nullable: false),
                    idIngrediente = table.Column<int>(type: "int", nullable: false),
                    Lancheid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adicionais", x => x.id);
                    table.ForeignKey(
                        name: "FK_adicionais_Lanches_Lancheid",
                        column: x => x.Lancheid,
                        principalTable: "Lanches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Lanches",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 4, "X-Egg Bacon" },
                    { 2, "X-Burger" },
                    { 1, "X-Bacon" },
                    { 3, "X-Egg" }
                });

            migrationBuilder.InsertData(
                table: "adicionais",
                columns: new[] { "id", "Lancheid", "idIngrediente" },
                values: new object[,]
                {
                    { 12, 4, 5 },
                    { 10, 4, 3 },
                    { 9, 4, 2 },
                    { 11, 4, 4 },
                    { 7, 3, 4 },
                    { 6, 3, 3 },
                    { 5, 2, 5 },
                    { 4, 2, 3 },
                    { 3, 1, 5 },
                    { 2, 1, 3 },
                    { 8, 3, 5 },
                    { 1, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "ingredientes",
                columns: new[] { "id", "nome", "preco" },
                values: new object[,]
                {
                    { 1, "Salada", 0.40m },
                    { 2, "Bacon", 2.00m },
                    { 3, "Hambúrger de Carne", 3.00m },
                    { 4, "Ovo", 0.80m },
                    { 5, "Queijo", 1.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_adicionais_Lancheid",
                table: "adicionais",
                column: "Lancheid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "adicionais");

            migrationBuilder.DropTable(
                name: "ingredientes");

            migrationBuilder.DropTable(
                name: "Lanches");
        }
    }
}
