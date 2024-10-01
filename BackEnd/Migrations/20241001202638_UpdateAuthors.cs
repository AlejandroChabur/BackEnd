using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_UserId",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Loans_UserId",
                table: "Loans");


            //migrationBuilder.DropColumn(
            //    name: "IsDeleted",
            //    table: "Users");

            //migrationBuilder.DropColumn(
            //    name: "IsDeleted",
            //    table: "Topics");

            //migrationBuilder.DropColumn(
            //    name: "IsDeleted",
            //    table: "Reports");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Loans");

            //migrationBuilder.DropColumn(
            //    name: "secondcode",
            //    table: "Books");

            //migrationBuilder.RenameColumn(
            //    name: "IdTopic",
            //    table: "Topics",
            //    newName: "Id");

            //migrationBuilder.RenameColumn(
            //    name: "IdPeople",
            //    table: "People",
            //    newName: "Id");

            //migrationBuilder.RenameColumn(
            //    name: "IdFormats",
            //    table: "Formats",
            //    newName: "Id");

            //migrationBuilder.RenameColumn(
            //    name: "IdEditorials",
            //    table: "Editorials",
            //    newName: "Id");

            //migrationBuilder.RenameColumn(
            //    name: "BookId",
            //    table: "Books",
            //    newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "Discriminator",
            //    table: "People",
            //    type: "nvarchar(8)",
            //    maxLength: 8,
            //    nullable: false,
            //    defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BooksXEditorials",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    EditorialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BooksXEditorials_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksXEditorials_Editorials_EditorialsId",
                        column: x => x.EditorialsId,
                        principalTable: "Editorials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksXFormats",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    FormatsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BooksXFormats_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksXFormats_Formats_FormatsId",
                        column: x => x.FormatsId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksXLoans",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    LoansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BooksXLoans_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksXLoans_Loans_LoansId",
                        column: x => x.LoansId,
                        principalTable: "Loans",
                        principalColumn: "IdLoans",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksXTopics",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BooksXTopics_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksXTopics_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooksXEditorials_BooksId",
                table: "BooksXEditorials",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXEditorials_EditorialsId",
                table: "BooksXEditorials",
                column: "EditorialsId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXFormats_BooksId",
                table: "BooksXFormats",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXFormats_FormatsId",
                table: "BooksXFormats",
                column: "FormatsId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXLoans_BooksId",
                table: "BooksXLoans",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXLoans_LoansId",
                table: "BooksXLoans",
                column: "LoansId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXTopics_BooksId",
                table: "BooksXTopics",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXTopics_TopicsId",
                table: "BooksXTopics",
                column: "TopicsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksXEditorials");

            migrationBuilder.DropTable(
                name: "BooksXFormats");

            migrationBuilder.DropTable(
                name: "BooksXLoans");

            migrationBuilder.DropTable(
                name: "BooksXTopics");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "People");

            //migrationBuilder.DropColumn(
            //    name: "Discriminator",
            //    table: "People");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Topics",
                newName: "IdTopic");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "People",
                newName: "IdPeople");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Formats",
                newName: "IdFormats");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Editorials",
                newName: "IdEditorials");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Books",
                newName: "BookId");

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsDeleted",
            //    table: "UserType",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsDeleted",
            //    table: "Users",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsDeleted",
            //    table: "Topics",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsDeleted",
            //    table: "Reports",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "secondcode",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    IdPeople = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.IdPeople);
                    table.ForeignKey(
                        name: "FK_Authors_People_IdPeople",
                        column: x => x.IdPeople,
                        principalTable: "People",
                        principalColumn: "IdPeople",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                table: "Loans",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_UserId",
                table: "Loans",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
