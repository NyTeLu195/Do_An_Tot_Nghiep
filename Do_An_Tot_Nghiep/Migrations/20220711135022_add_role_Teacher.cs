using Microsoft.EntityFrameworkCore.Migrations;

namespace Do_An_Tot_Nghiep.Migrations
{
    public partial class add_role_Teacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "TeacherEntity",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "TeacherEntity");
        }
    }
}
