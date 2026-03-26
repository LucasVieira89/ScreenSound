using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScreenSound.Share.Dados.Migrations
{
    /// <inheritdoc />
    public partial class TabelaPopular : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    Disponivel = table.Column<bool>(type: "bit", nullable: false),
                    AnoDeLancamento = table.Column<int>(type: "int", nullable: true),
                    ArtistaId = table.Column<int>(type: "int", nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Musica_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Musica_Artistas_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artistas",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Artistas",
                columns: new[] { "Id", "Bio", "FotoPerfil", "Nome" },
                values: new object[,]
                {
                    { 1, "Cantor e compositor brasileiro conhecido pela mistura de MPB, jazz e funk.", "https://upload.wikimedia.org/wikipedia/commons/5/5a/Djavan_2012.jpg", "Djavan" },
                    { 2, "Banda de rock alternativo formada por Dave Grohl após o Nirvana.", "https://upload.wikimedia.org/wikipedia/commons/9/9f/Foo_Fighters_2017.jpg", "Foo Fighters" },
                    { 3, "Cantor e ator americano, um dos maiores nomes da música do século XX.", "https://upload.wikimedia.org/wikipedia/commons/a/af/Frank_Sinatra_1960.jpg", "Frank Sinatra" },
                    { 4, "Pioneiro da soul music, combinando gospel, blues e jazz.", "https://upload.wikimedia.org/wikipedia/commons/8/87/Ray_Charles_1968.jpg", "Ray Charles" },
                    { 5, "Lendário guitarrista e cantor de blues, conhecido como 'Rei do Blues'.", "https://upload.wikimedia.org/wikipedia/commons/9/9c/BB_King_2009.jpg", "B.B. King" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Musica_AlbumId",
                table: "Musica",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Musica_ArtistaId",
                table: "Musica",
                column: "ArtistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Musica");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Artistas");
        }
    }
}
