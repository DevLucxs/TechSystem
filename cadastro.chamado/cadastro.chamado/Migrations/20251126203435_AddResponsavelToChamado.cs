using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro.chamado.Migrations
{
    /// <inheritdoc />
    public partial class AddResponsavelToChamado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                value: "$2a$11$DQ4sL.LxzcPcMRCNspy81uAynmRBUHAx672LWLthg/sEKpWRnLrWi");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$T20ywXXTOCht9Bml//Djf.Oi8tbuWrmArH/Fvvgbxe4rSrqqJqddG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categoria",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "Equipe",
                table: "Chamados");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$11$zjIbTBzaMNoijjppRjw/A.7HKGjcWhYGagU8UT8KrNjh.LtO8Bbwq");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$BpsoSZhiA680/cQldjRJKec1Jkf8jpxLabELoY/qzkiCDg1EeuMMm");
        }
    }
}
