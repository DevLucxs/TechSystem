using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cadastro.chamado.Migrations
{
    /// <inheritdoc />
    public partial class AddRelatorios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Notificacoes",
                columns: new[] { "Id", "CriadoEm", "Icone", "Mensagem", "Tempo", "Tipo", "Titulo" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 26, 1, 5, 21, 442, DateTimeKind.Local).AddTicks(934), "✅", "Seu relatório foi salvo no sistema.", "Agora", "sucesso", "Relatório enviado com sucesso" },
                    { 2, new DateTime(2025, 11, 26, 1, 5, 21, 442, DateTimeKind.Local).AddTicks(936), "⚠️", "Você tem até às 18h para enviar o relatório.", "1 hora atrás", "alerta", "Prazo final para envio" }
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$11$8JMcPDZ4hkMhXLX52jzsOOIrjn/8jWchTSjScbEVh5/Qtumi6U9QK");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$2xNZuhYH4wRNNX71TG5iu.sgQdYiV0UQlFwKdlMuE1vdA1Ez6qbTa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notificacoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notificacoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "SenhaHash",
                value: "$2a$11$b.2//P8KCrq9cWnmmPoYsOdM6OwLQXJ9FjhtY0wv2D6IXXpNy3ZKa");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "SenhaHash",
                value: "$2a$11$8UnlIS2NXsulNCPzUPvFTOVv1Q79qo6DQ7OYScSA2QWHgdQDnF1qi");
        }
    }
}
