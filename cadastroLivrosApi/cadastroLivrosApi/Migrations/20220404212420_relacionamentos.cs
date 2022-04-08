using Microsoft.EntityFrameworkCore.Migrations;

namespace cadastroLivrosApi.Migrations
{
    public partial class relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Livros");

            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoresLivro",
                columns: table => new
                {
                    AutoresId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresLivro", x => new { x.AutoresId, x.LivroId });
                    table.ForeignKey(
                        name: "FK_AutoresLivro_Autores_AutoresId",
                        column: x => x.AutoresId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoresLivro_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoresLivro_LivroId",
                table: "AutoresLivro",
                column: "LivroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoresLivro");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Livros",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");
        }
    }
}
