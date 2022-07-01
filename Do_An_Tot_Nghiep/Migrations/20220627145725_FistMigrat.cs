using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Do_An_Tot_Nghiep.Migrations
{
    public partial class FistMigrat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentsEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FisrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Process = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FisrtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ViolationEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PenaltyPoint = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViolationEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceEntity_StudentsEntity_StudentsEntityId",
                        column: x => x.StudentsEntityId,
                        principalTable: "StudentsEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ViolationHistoryEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreataID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViolationHistoryEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViolationHistoryEntity_StudentsEntity_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "StudentsEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassroomEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    TeacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TeacherEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TotalNumberStudent = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassroomEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassroomEntity_TeacherEntity_TeacherEntityId",
                        column: x => x.TeacherEntityId,
                        principalTable: "TeacherEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ClassroomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassroomEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentEntity_ClassroomEntity_ClassroomEntityId",
                        column: x => x.ClassroomEntityId,
                        principalTable: "ClassroomEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssignmentEntity_TeacherEntity_TeacherEntityId",
                        column: x => x.TeacherEntityId,
                        principalTable: "TeacherEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassRoomID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassroomEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Semester = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterEntity_ClassroomEntity_ClassroomEntityId",
                        column: x => x.ClassroomEntityId,
                        principalTable: "ClassroomEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegisterDetailEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegisterEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssignmentID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignmentEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Scores = table.Column<float>(type: "real", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserCreataID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserUpdateID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterDetailEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisterDetailEntity_AssignmentEntity_AssignmentEntityId",
                        column: x => x.AssignmentEntityId,
                        principalTable: "AssignmentEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegisterDetailEntity_RegisterEntity_RegisterEntityId",
                        column: x => x.RegisterEntityId,
                        principalTable: "RegisterEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentEntity_ClassroomEntityId",
                table: "AssignmentEntity",
                column: "ClassroomEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentEntity_TeacherEntityId",
                table: "AssignmentEntity",
                column: "TeacherEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceEntity_StudentsEntityId",
                table: "AttendanceEntity",
                column: "StudentsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassroomEntity_TeacherEntityId",
                table: "ClassroomEntity",
                column: "TeacherEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterDetailEntity_AssignmentEntityId",
                table: "RegisterDetailEntity",
                column: "AssignmentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterDetailEntity_RegisterEntityId",
                table: "RegisterDetailEntity",
                column: "RegisterEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterEntity_ClassroomEntityId",
                table: "RegisterEntity",
                column: "ClassroomEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ViolationHistoryEntity_StudentsId",
                table: "ViolationHistoryEntity",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceEntity");

            migrationBuilder.DropTable(
                name: "RegisterDetailEntity");

            migrationBuilder.DropTable(
                name: "ViolationEntity");

            migrationBuilder.DropTable(
                name: "ViolationHistoryEntity");

            migrationBuilder.DropTable(
                name: "AssignmentEntity");

            migrationBuilder.DropTable(
                name: "RegisterEntity");

            migrationBuilder.DropTable(
                name: "StudentsEntity");

            migrationBuilder.DropTable(
                name: "ClassroomEntity");

            migrationBuilder.DropTable(
                name: "TeacherEntity");
        }
    }
}
