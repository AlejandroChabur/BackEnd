using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CreateAuthorsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_people_identificationTypes_IdentificationTypeId",
                table: "people");

            migrationBuilder.DropPrimaryKey(
                name: "PK_people",
                table: "people");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "people");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "people");

            migrationBuilder.RenameTable(
                name: "people",
                newName: "People");

            migrationBuilder.RenameIndex(
                name: "IX_people_IdentificationTypeId",
                table: "People",
                newName: "IX_People_IdentificationTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdPersona",
                table: "Users",
                column: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_People_identificationTypes_IdentificationTypeId",
                table: "People",
                column: "IdentificationTypeId",
                principalTable: "identificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_People_IdPersona",
                table: "Users",
                column: "IdPersona",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_identificationTypes_IdentificationTypeId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_People_IdPersona",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdPersona",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "people");

            migrationBuilder.RenameIndex(
                name: "IX_People_IdentificationTypeId",
                table: "people",
                newName: "IX_people_IdentificationTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "people",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "people",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_people",
                table: "people",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_people_identificationTypes_IdentificationTypeId",
                table: "people",
                column: "IdentificationTypeId",
                principalTable: "identificationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
