using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorsXBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_People_IdPeople",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "IdPeople",
                table: "People",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdPeople",
                table: "Authors",
                newName: "IdPersona");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Authors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BooksBookId",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Authors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "authorsXBooks",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    AuthorsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_authorsXBooks_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_authorsXBooks_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksXEditorials",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    EditorialsIdEditorials = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BooksXEditorials_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksXEditorials_Editorials_EditorialsIdEditorials",
                        column: x => x.EditorialsIdEditorials,
                        principalTable: "Editorials",
                        principalColumn: "IdEditorials",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksXFormats",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    FormatsIdFormats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BooksXFormats_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksXFormats_Formats_FormatsIdFormats",
                        column: x => x.FormatsIdFormats,
                        principalTable: "Formats",
                        principalColumn: "IdFormats",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksXLoans",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    LoansIdLoans = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BooksXLoans_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksXLoans_Loans_LoansIdLoans",
                        column: x => x.LoansIdLoans,
                        principalTable: "Loans",
                        principalColumn: "IdLoans",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooksXTopics",
                columns: table => new
                {
                    BooksBookId = table.Column<int>(type: "int", nullable: false),
                    TopicsIdTopic = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_BooksXTopics_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksXTopics_Topics_TopicsIdTopic",
                        column: x => x.TopicsIdTopic,
                        principalTable: "Topics",
                        principalColumn: "IdTopic",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_BooksBookId",
                table: "Authors",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_IdPersona",
                table: "Authors",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_authorsXBooks_AuthorsId",
                table: "authorsXBooks",
                column: "AuthorsId");

            migrationBuilder.CreateIndex(
                name: "IX_authorsXBooks_BooksBookId",
                table: "authorsXBooks",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXEditorials_BooksBookId",
                table: "BooksXEditorials",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXEditorials_EditorialsIdEditorials",
                table: "BooksXEditorials",
                column: "EditorialsIdEditorials");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXFormats_BooksBookId",
                table: "BooksXFormats",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXFormats_FormatsIdFormats",
                table: "BooksXFormats",
                column: "FormatsIdFormats");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXLoans_BooksBookId",
                table: "BooksXLoans",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXLoans_LoansIdLoans",
                table: "BooksXLoans",
                column: "LoansIdLoans");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXTopics_BooksBookId",
                table: "BooksXTopics",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksXTopics_TopicsIdTopic",
                table: "BooksXTopics",
                column: "TopicsIdTopic");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BooksBookId",
                table: "Authors",
                column: "BooksBookId",
                principalTable: "Books",
                principalColumn: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_People_IdPersona",
                table: "Authors",
                column: "IdPersona",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BooksBookId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Authors_People_IdPersona",
                table: "Authors");

            migrationBuilder.DropTable(
                name: "authorsXBooks");

            migrationBuilder.DropTable(
                name: "BooksXEditorials");

            migrationBuilder.DropTable(
                name: "BooksXFormats");

            migrationBuilder.DropTable(
                name: "BooksXLoans");

            migrationBuilder.DropTable(
                name: "BooksXTopics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_BooksBookId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_IdPersona",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "BooksBookId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "People",
                newName: "IdPeople");

            migrationBuilder.RenameColumn(
                name: "IdPersona",
                table: "Authors",
                newName: "IdPeople");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Authors",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "IdPeople");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_People_IdPeople",
                table: "Authors",
                column: "IdPeople",
                principalTable: "People",
                principalColumn: "IdPeople",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
