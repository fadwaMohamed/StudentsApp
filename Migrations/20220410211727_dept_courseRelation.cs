using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task1_EF.Migrations
{
    public partial class dept_courseRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseDepartment",
                columns: table => new
                {
                    CoursesDepartmentsDeptId = table.Column<int>(type: "int", nullable: false),
                    DepartmentCoursesCrsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDepartment", x => new { x.CoursesDepartmentsDeptId, x.DepartmentCoursesCrsId });
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Courses_DepartmentCoursesCrsId",
                        column: x => x.DepartmentCoursesCrsId,
                        principalTable: "Courses",
                        principalColumn: "CrsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseDepartment_Departments_CoursesDepartmentsDeptId",
                        column: x => x.CoursesDepartmentsDeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentCoursesCrsId",
                table: "CourseDepartment",
                column: "DepartmentCoursesCrsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseDepartment");
        }
    }
}
