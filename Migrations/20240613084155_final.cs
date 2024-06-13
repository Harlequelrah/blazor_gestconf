using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blazor_gestconf.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Entreprises_EntrepriseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Universites_UniversiteId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Relectures_AspNetUsers_AuteurId",
                table: "Relectures");

            migrationBuilder.AlterColumn<int>(
                name: "AuteurId",
                table: "Relectures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Entreprises_EntrepriseId",
                table: "AspNetUsers",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Universites_UniversiteId",
                table: "AspNetUsers",
                column: "UniversiteId",
                principalTable: "Universites",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Relectures_AspNetUsers_AuteurId",
                table: "Relectures",
                column: "AuteurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Entreprises_EntrepriseId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Universites_UniversiteId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Relectures_AspNetUsers_AuteurId",
                table: "Relectures");

            migrationBuilder.AlterColumn<int>(
                name: "AuteurId",
                table: "Relectures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Entreprises_EntrepriseId",
                table: "AspNetUsers",
                column: "EntrepriseId",
                principalTable: "Entreprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Universites_UniversiteId",
                table: "AspNetUsers",
                column: "UniversiteId",
                principalTable: "Universites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Relectures_AspNetUsers_AuteurId",
                table: "Relectures",
                column: "AuteurId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
