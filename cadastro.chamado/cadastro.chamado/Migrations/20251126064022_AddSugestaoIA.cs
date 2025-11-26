using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro.chamado.Migrations
{
    /// <inheritdoc />
    public partial class AddSugestaoIA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SugestaoIA",
                table: "Chamados",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$11$C8kflcH2a9QgweSYi8lTU..PwujqItGig8ykOCcQFhC98GhJigMRi");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$4HfmGMcuZlqt6abqqTbUL.7FrSMEQW7M7ioDojUIEW8QfmGikqCbi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SugestaoIA",
                table: "Chamados");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$11$.DlNggwfvFUIGUdhVzd2JuyT7K.xOcRjsxo387CzO69DhPF9li9H6");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$OW8FRNTXwnnATIU0n8VEdOgH7zg8P1i9vOGykT9BevwSybsWquAg.");
        }
    }
}
