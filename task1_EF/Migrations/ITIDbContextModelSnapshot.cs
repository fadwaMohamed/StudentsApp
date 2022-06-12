﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using task1_EF.Data;

#nullable disable

namespace task1_EF.Migrations
{
    [DbContext(typeof(ITIDbContext))]
    partial class ITIDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("CoursesDepartmentsDeptId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentCoursesCrsId")
                        .HasColumnType("int");

                    b.HasKey("CoursesDepartmentsDeptId", "DepartmentCoursesCrsId");

                    b.HasIndex("DepartmentCoursesCrsId");

                    b.ToTable("CourseDepartment");
                });

            modelBuilder.Entity("task1_EF.Models.Course", b =>
                {
                    b.Property<int>("CrsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CrsId"), 1L, 1);

                    b.Property<string>("CrsName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CrsId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("task1_EF.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeptId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("task1_EF.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("DeptNo")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StdImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("task1_EF.Models.StudentCourse", b =>
                {
                    b.Property<int>("StdId")
                        .HasColumnType("int");

                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.HasKey("StdId", "CrsId");

                    b.HasIndex("CrsId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("task1_EF.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("CoursesDepartmentsDeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task1_EF.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("DepartmentCoursesCrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("task1_EF.Models.Student", b =>
                {
                    b.HasOne("task1_EF.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DeptNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("task1_EF.Models.StudentCourse", b =>
                {
                    b.HasOne("task1_EF.Models.Course", "Course")
                        .WithMany("CourceStudents")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("task1_EF.Models.Student", "Student")
                        .WithMany("studentCources")
                        .HasForeignKey("StdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("task1_EF.Models.Course", b =>
                {
                    b.Navigation("CourceStudents");
                });

            modelBuilder.Entity("task1_EF.Models.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("task1_EF.Models.Student", b =>
                {
                    b.Navigation("studentCources");
                });
#pragma warning restore 612, 618
        }
    }
}
