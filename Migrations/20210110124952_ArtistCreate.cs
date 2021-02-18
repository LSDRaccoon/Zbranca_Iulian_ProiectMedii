using Microsoft.EntityFrameworkCore.Migrations;

namespace Zbranca_Iulian_ProiectMedii.Migrations
{
    public partial class ArtistCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Album");

            migrationBuilder.AddColumn<int>(
                name: "ArtistID",
                table: "Album",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LabelID",
                table: "Album",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_LabelID",
                table: "Album",
                column: "LabelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Label_LabelID",
                table: "Album",
                column: "LabelID",
                principalTable: "Label",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Label_LabelID",
                table: "Album");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropIndex(
                name: "IX_Album_LabelID",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "ArtistID",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "LabelID",
                table: "Album");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Album",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
