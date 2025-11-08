using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 152, 114, 202, 26, 213, 80, 255, 58, 109, 143, 193, 106, 3, 74, 35, 240, 105, 171, 87, 97, 36, 92, 148, 97, 193, 146, 21, 90, 243, 26, 217, 116, 55, 114, 239, 201, 214, 185, 108, 130, 79, 107, 199, 152, 143, 80, 32, 177, 214, 48, 101, 137, 191, 205, 75, 188, 124, 233, 0, 103, 190, 85, 11, 175 }, new byte[] { 89, 205, 34, 130, 244, 76, 5, 160, 215, 60, 6, 244, 70, 136, 11, 239, 33, 152, 107, 152, 88, 93, 165, 104, 147, 90, 191, 211, 81, 122, 102, 51, 166, 19, 118, 56, 170, 52, 192, 53, 55, 204, 232, 34, 51, 31, 100, 159, 150, 172, 237, 29, 6, 98, 81, 145, 126, 3, 193, 51, 63, 191, 39, 242, 98, 214, 227, 80, 156, 29, 4, 40, 12, 72, 142, 254, 123, 162, 141, 159, 102, 173, 233, 52, 204, 228, 1, 165, 227, 235, 126, 27, 237, 100, 207, 139, 181, 164, 221, 248, 181, 56, 123, 12, 118, 31, 1, 197, 49, 166, 158, 236, 207, 74, 25, 94, 201, 66, 230, 176, 146, 140, 82, 76, 57, 95, 33, 218 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 20, 240, 59, 126, 111, 164, 194, 0, 250, 192, 122, 68, 47, 144, 72, 77, 175, 140, 158, 29, 138, 32, 154, 239, 139, 87, 193, 159, 135, 240, 147, 203, 72, 5, 74, 76, 222, 19, 174, 206, 203, 34, 207, 34, 163, 239, 51, 225, 110, 51, 167, 155, 158, 254, 229, 101, 170, 88, 46, 220, 196, 112, 210, 224 }, new byte[] { 230, 42, 167, 58, 240, 191, 147, 200, 23, 7, 4, 10, 160, 89, 42, 17, 45, 200, 197, 104, 89, 188, 159, 83, 54, 48, 43, 157, 247, 51, 239, 46, 95, 210, 154, 108, 118, 198, 142, 77, 77, 137, 88, 117, 181, 206, 238, 12, 121, 54, 79, 14, 100, 62, 44, 61, 151, 67, 108, 184, 252, 185, 156, 193, 63, 27, 48, 53, 167, 112, 117, 251, 88, 153, 133, 3, 230, 63, 254, 91, 101, 39, 159, 208, 40, 72, 150, 114, 213, 203, 234, 89, 21, 116, 107, 1, 94, 211, 116, 235, 200, 80, 145, 199, 139, 8, 215, 15, 251, 138, 75, 144, 240, 180, 71, 48, 172, 74, 7, 46, 32, 223, 44, 222, 64, 199, 65, 152 } });
        }
    }
}
