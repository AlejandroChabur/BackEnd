﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

public partial class CreatePeopleTable : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "People",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                IdentificationTypeId = table.Column<int>(type: "int", nullable: false), // Asumiendo que IdentificationType es una entidad relacionada
                IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                SecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Borndate = table.Column<DateOnly>(type: "date", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_people", x => x.Id);
                table.ForeignKey(
                    name: "FK_people_identification_types_IdentificationTypeId",
                    column: x => x.IdentificationTypeId,
                    principalTable: "identification_types", // Cambia esto por el nombre de tu tabla de IdentificationType
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_people_IdentificationTypeId",
            table: "People",
            column: "IdentificationTypeId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "People");
    }
}

