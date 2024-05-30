using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjectEntity_Students_StudentId",
                table: "StudentSubjectEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjectEntity_Subjects_SubjectId",
                table: "StudentSubjectEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubjectEntity",
                table: "StudentSubjectEntity");

            migrationBuilder.RenameTable(
                name: "StudentSubjectEntity",
                newName: "StudentSubject");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjectEntity_SubjectId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjectEntity_StudentId",
                table: "StudentSubject",
                newName: "IX_StudentSubject_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Students_StudentId",
                table: "StudentSubject",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectId",
                table: "StudentSubject",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Students_StudentId",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_Subjects_SubjectId",
                table: "StudentSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject");

            migrationBuilder.RenameTable(
                name: "StudentSubject",
                newName: "StudentSubjectEntity");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_SubjectId",
                table: "StudentSubjectEntity",
                newName: "IX_StudentSubjectEntity_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_StudentId",
                table: "StudentSubjectEntity",
                newName: "IX_StudentSubjectEntity_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubjectEntity",
                table: "StudentSubjectEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjectEntity_Students_StudentId",
                table: "StudentSubjectEntity",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjectEntity_Subjects_SubjectId",
                table: "StudentSubjectEntity",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
