using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Actions_ActionId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_ActionId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "ActionId",
                table: "Grades",
                newName: "GradeDate");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Subjects",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ActivityId",
                table: "Grades",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "GradeValue",
                table: "Grades",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ActivityId",
                table: "Grades",
                column: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Actions_ActivityId",
                table: "Grades",
                column: "ActivityId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Actions_ActivityId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_ActivityId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradeValue",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "GradeDate",
                table: "Grades",
                newName: "ActionId");

            migrationBuilder.AddColumn<double>(
                name: "Score",
                table: "Grades",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_ActionId",
                table: "Grades",
                column: "ActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Actions_ActionId",
                table: "Grades",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
