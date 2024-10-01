using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"), // Clave primaria con identidad
                    IdPersona = table.Column<int>(type: "int", nullable: false), // Clave foránea hacia Persona
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false) // Clave foránea hacia UserType
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_people_IdPersona", // Nombre de la restricción
                        column: x => x.IdPersona,
                        principalTable: "people", // Tabla de referencia
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // Comportamiento de eliminación

                    table.ForeignKey(
                        name: "FK_users_userTypes_UserTypeId", // Nombre de la restricción
                        column: x => x.UserTypeId,
                        principalTable: "userTypes", // Tabla de referencia
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); // Comportamiento de eliminación
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_IdPersona",
                table: "users",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_users_UserTypeId",
                table: "users",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
