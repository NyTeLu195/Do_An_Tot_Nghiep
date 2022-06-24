using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Do_An_Tot_Nghiep.Migrations
{
    public partial class _3Migation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_Teacher_TeacherID",
                table: "Classroom");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherID",
                table: "Classroom",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_Teacher_TeacherID",
                table: "Classroom",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_Teacher_TeacherID",
                table: "Classroom");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherID",
                table: "Classroom",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_Teacher_TeacherID",
                table: "Classroom",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
