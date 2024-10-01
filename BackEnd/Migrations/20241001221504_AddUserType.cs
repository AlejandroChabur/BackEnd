using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddUserType: Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Clave primaria con identidad
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false) // Campo requerido para el nombre del tipo de usuario
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id); // Definir la clave primaria
                });
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "userTypes");
        //}
    }
}