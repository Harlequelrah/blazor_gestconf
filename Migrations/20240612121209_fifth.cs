using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blazor_gestconf.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelectureId",
                table: "Articles");

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Relectures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Relectures_ArticleId",
                table: "Relectures",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Relectures_Articles_ArticleId",
                table: "Relectures",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Relectures_Articles_ArticleId",
                table: "Relectures");

            migrationBuilder.DropIndex(
                name: "IX_Relectures_ArticleId",
                table: "Relectures");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Relectures");

            migrationBuilder.AddColumn<string>(
                name: "RelectureId",
                table: "Articles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
