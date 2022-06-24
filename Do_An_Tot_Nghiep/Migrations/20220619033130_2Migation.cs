using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Do_An_Tot_Nghiep.Migrations
{
    public partial class _2Migation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_Teacher_HomeroomTeacherID",
                table: "Classroom");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_HomeroomTeacherID",
                table: "Classroom");

            migrationBuilder.DropColumn(
                name: "HomeroomTeacherID",
                table: "Classroom");

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_TeacherID",
                table: "Classroom",
                column: "TeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_Teacher_TeacherID",
                table: "Classroom",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classroom_Teacher_TeacherID",
                table: "Classroom");

            migrationBuilder.DropIndex(
                name: "IX_Classroom_TeacherID",
                table: "Classroom");

            migrationBuilder.AddColumn<Guid>(
                name: "HomeroomTeacherID",
                table: "Classroom",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classroom_HomeroomTeacherID",
                table: "Classroom",
                column: "HomeroomTeacherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Classroom_Teacher_HomeroomTeacherID",
                table: "Classroom",
                column: "HomeroomTeacherID",
                principalTable: "Teacher",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
