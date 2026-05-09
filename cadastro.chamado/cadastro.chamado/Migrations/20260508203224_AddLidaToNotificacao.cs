using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro.chamado.Migrations
{
    /// <inheritdoc />
    public partial class AddLidaToNotificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Lida",
                table: "Notificacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$11$UYQYkfwiPlrV.YXDECFXYue/csSBIqfxwUaToxLhc0AAoj.7WgIty");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$L3MVNQYCOJXCHYITqnf8S.vHIpf1xuEe1iwfWODWqjjO9nbABqv1G");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lida",
                table: "Notificacoes");

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
    }
}
