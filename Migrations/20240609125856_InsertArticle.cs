using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blazor_gestconf.Migrations
{
    /// <inheritdoc />
    public partial class InsertArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Statut",
                table: "Articles",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ConferenceId",
                table: "Articles",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Conferences_ConferenceId",
                table: "Articles",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Conferences_ConferenceId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_ConferenceId",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Statut",
                keyValue: null,
                column: "Statut",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Statut",
                table: "Articles",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
