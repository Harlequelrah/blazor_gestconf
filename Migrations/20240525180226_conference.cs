using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blazor_gestconf.Migrations
{
    /// <inheritdoc />
    public partial class conference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleProofReaders_Relectures_RelectureId",
                table: "ArticleProofReaders");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateConferenceDebut",
                table: "Conferences",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateConferenceFin",
                table: "Conferences",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateInscriptionDebut",
                table: "Conferences",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateInscriptionFin",
                table: "Conferences",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemiseResultats",
                table: "Conferences",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSoumissionDebut",
                table: "Conferences",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSoumissionFin",
                table: "Conferences",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Conferences",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Sigle",
                table: "Conferences",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Conferences",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleProofReaders_Relectures_RelectureId",
                table: "ArticleProofReaders",
                column: "RelectureId",
                principalTable: "Relectures",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleProofReaders_Relectures_RelectureId",
                table: "ArticleProofReaders");

            migrationBuilder.DropColumn(
                name: "DateConferenceDebut",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "DateConferenceFin",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "DateInscriptionDebut",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "DateInscriptionFin",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "DateRemiseResultats",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "DateSoumissionDebut",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "DateSoumissionFin",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "Sigle",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Conferences");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleProofReaders_Relectures_RelectureId",
                table: "ArticleProofReaders",
                column: "RelectureId",
                principalTable: "Relectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
