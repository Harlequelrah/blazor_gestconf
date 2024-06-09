using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blazor_gestconf.Migrations
{
    /// <inheritdoc />
    public partial class universiteentreprise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entreprise",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Universite",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "EntrepriseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UniversiteId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Entreprises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entreprises", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Universites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universites", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EntrepriseId",
                table: "AspNetUsers",
                column: "EntrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UniversiteId",
                table: "AspNetUsers",
                column: "UniversiteId");

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

            migrationBuilder.DropTable(
                name: "Entreprises");

            migrationBuilder.DropTable(
                name: "Universites");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EntrepriseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UniversiteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EntrepriseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UniversiteId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Entreprise",
                table: "AspNetUsers",
                type: "varchar(100)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Universite",
                table: "AspNetUsers",
                type: "varchar(100)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
