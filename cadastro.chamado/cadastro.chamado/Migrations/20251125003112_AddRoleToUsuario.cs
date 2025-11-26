using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cadastro.chamado.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenhaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Email", "Nome", "Role", "SenhaHash" },
                values: new object[,]
                {
                    { 1, "admin@techsystem.com", "Administrador", "Admin", "$2a$11$idtIHGsi3ys92CVkE0psSuk9HwOzzfwU56w7ao7G2KKxym68JlMja" },
                    { 2, "usuario@techsystem.com", "Usuário Comum", "Usuario", "$2a$11$h8R0hz.Ls5u78XvUOjqqNOHez7iR3.RR519twdF7aKnGCMg49kMqi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
