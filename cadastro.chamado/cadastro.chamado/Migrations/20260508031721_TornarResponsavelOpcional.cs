using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro.chamado.Migrations
{
    /// <inheritdoc />
    public partial class TornarResponsavelOpcional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "Equipe",
                table: "Chamados");

            migrationBuilder.AlterColumn<string>(
                name: "SugestaoIA",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Prioridade",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$11$TbGJJ0boSyG3wnCXvCdc.eueD5p0qQS4hZTXMqweXIcaeq3vXp8A.");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$AMsj2RcWV3nKAqv4bBF7tuQ6KaLAIwJxNKjum6GTYTEDlShvfbtfS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SugestaoIA",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Responsavel",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Prioridade",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Categoria",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Equipe",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$11$vgDW0ZJE0j7mm0gckQozdO9Su6aW4ouNwWOASvtemjCRUVN7VMMcO");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$hqYdF1kQtnffWGscFdo61.SO9KqHsdTXpXctY8TF/nzwCufdBNY.W");
        }
    }
}
