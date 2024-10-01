using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddReports : Migration
    {
        /// <inheritdoc />
      protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "reports",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                LoansId = table.Column<int>(type: "int", nullable: false), // Clave foránea hacia Loans
                Comment = table.Column<string>(type: "nvarchar(max)", nullable: true) // Comentario opcional
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_reports", x => x.Id);
                table.ForeignKey(
                    name: "FK_reports_loans_Id",
                    column: x => x.LoansId,
                    principalTable: "loans",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade); // Comportamiento de eliminación
            });

        migrationBuilder.CreateIndex(
            name: "IX_reports_LoansId",
            table: "reports",
            column: "LoansId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "reports");
    }
    }
}
