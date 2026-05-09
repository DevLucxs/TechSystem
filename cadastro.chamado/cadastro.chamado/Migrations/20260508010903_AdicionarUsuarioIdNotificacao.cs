using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro.chamado.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarUsuarioIdNotificacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.RenameColumn(
              //  name: "Descricao",
             //   table: "Relatorios",
           //     newName: "Mensagem");
            
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Notificacoes",
                type: "int",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Notificacoes");

            migrationBuilder.RenameColumn(
                name: "Mensagem",
                table: "Relatorios",
                newName: "Descricao");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$11$DQ4sL.LxzcPcMRCNspy81uAynmRBUHAx672LWLthg/sEKpWRnLrWi");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$T20ywXXTOCht9Bml//Djf.Oi8tbuWrmArH/Fvvgbxe4rSrqqJqddG");
        }
    }
}
