using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGNS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGNS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGNS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGNS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 10, "Lentidão" },
                    { 2, 12, "Ceguera" },
                    { 3, 15, "Caimbra" },
                    { 4, 30, "Estocada" },
                    { 5, 20, "Dose de oraçao" },
                    { 6, 40, "Arremesso de orbe" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 34, 238, 5, 81, 223, 171, 16, 161, 126, 167, 160, 244, 147, 162, 65, 96, 8, 230, 78, 135, 145, 39, 53, 31, 96, 144, 175, 55, 108, 113, 236, 92, 4, 201, 33, 130, 50, 27, 43, 200, 3, 12, 50, 226, 138, 8, 21, 21, 20, 131, 215, 109, 10, 211, 182, 22, 236, 94, 221, 157, 239, 216, 145, 107 }, new byte[] { 111, 74, 196, 192, 57, 77, 173, 9, 81, 133, 176, 97, 130, 77, 244, 252, 212, 130, 32, 90, 55, 11, 169, 22, 57, 239, 61, 163, 141, 47, 25, 34, 49, 247, 251, 26, 164, 142, 79, 83, 136, 219, 7, 244, 56, 59, 153, 121, 58, 51, 2, 225, 68, 152, 186, 7, 150, 5, 213, 101, 80, 237, 1, 250, 4, 221, 94, 145, 56, 45, 43, 72, 43, 222, 2, 43, 119, 205, 198, 55, 227, 139, 165, 109, 21, 39, 147, 18, 74, 153, 120, 231, 143, 104, 45, 244, 2, 164, 198, 145, 174, 79, 101, 150, 243, 254, 44, 0, 176, 2, 188, 191, 216, 47, 168, 248, 145, 138, 135, 147, 250, 214, 252, 45, 0, 1, 228, 159 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGNS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGNS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGNS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGNS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 114, 202, 26, 213, 80, 255, 58, 109, 143, 193, 106, 3, 74, 35, 240, 105, 171, 87, 97, 36, 92, 148, 97, 193, 146, 21, 90, 243, 26, 217, 116, 55, 114, 239, 201, 214, 185, 108, 130, 79, 107, 199, 152, 143, 80, 32, 177, 214, 48, 101, 137, 191, 205, 75, 188, 124, 233, 0, 103, 190, 85, 11, 175 }, new byte[] { 89, 205, 34, 130, 244, 76, 5, 160, 215, 60, 6, 244, 70, 136, 11, 239, 33, 152, 107, 152, 88, 93, 165, 104, 147, 90, 191, 211, 81, 122, 102, 51, 166, 19, 118, 56, 170, 52, 192, 53, 55, 204, 232, 34, 51, 31, 100, 159, 150, 172, 237, 29, 6, 98, 81, 145, 126, 3, 193, 51, 63, 191, 39, 242, 98, 214, 227, 80, 156, 29, 4, 40, 12, 72, 142, 254, 123, 162, 141, 159, 102, 173, 233, 52, 204, 228, 1, 165, 227, 235, 126, 27, 237, 100, 207, 139, 181, 164, 221, 248, 181, 56, 123, 12, 118, 31, 1, 197, 49, 166, 158, 236, 207, 74, 25, 94, 201, 66, 230, 176, 146, 140, 82, 76, 57, 95, 33, 218 } });
        }
    }
}
