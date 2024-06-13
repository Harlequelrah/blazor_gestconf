using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace blazor_gestconf.Migrations
{
    /// <inheritdoc />
    public partial class nine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantAviss_AspNetUsers_ParticpantId",
                table: "ParticipantAviss");

            migrationBuilder.RenameColumn(
                name: "ParticpantId",
                table: "ParticipantAviss",
                newName: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantAviss_AspNetUsers_ParticipantId",
                table: "ParticipantAviss",
                column: "ParticipantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantAviss_AspNetUsers_ParticipantId",
                table: "ParticipantAviss");

            migrationBuilder.RenameColumn(
                name: "ParticipantId",
                table: "ParticipantAviss",
                newName: "ParticpantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantAviss_AspNetUsers_ParticpantId",
                table: "ParticipantAviss",
                column: "ParticpantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
