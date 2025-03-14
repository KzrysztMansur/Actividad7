﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using actividad7.Data;

#nullable disable

namespace actividad7.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("actividad7.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KitId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("KitId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("actividad7.Models.CourseGroup", b =>
                {
                    b.Property<int>("CourseGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseGroupId"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("CourseGroupId");

                    b.HasIndex("CourseId");

                    b.HasIndex("GroupId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseGroups");
                });

            modelBuilder.Entity("actividad7.Models.CourseUser", b =>
                {
                    b.Property<int>("CourseUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseUserId"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CourseUserId");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("CourseUsers");
                });

            modelBuilder.Entity("actividad7.Models.Group", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupId"));

                    b.Property<string>("GroupLabel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GroupId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("actividad7.Models.Kit", b =>
                {
                    b.Property<int>("KitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KitId"));

                    b.Property<string>("KitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KitId");

                    b.ToTable("Kits");
                });

            modelBuilder.Entity("actividad7.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("actividad7.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("actividad7.Models.Course", b =>
                {
                    b.HasOne("actividad7.Models.Kit", "Kit")
                        .WithMany("Courses")
                        .HasForeignKey("KitId");

                    b.Navigation("Kit");
                });

            modelBuilder.Entity("actividad7.Models.CourseGroup", b =>
                {
                    b.HasOne("actividad7.Models.Course", "Course")
                        .WithMany("CourseGroups")
                        .HasForeignKey("CourseId");

                    b.HasOne("actividad7.Models.Group", "Group")
                        .WithMany("CourseGroups")
                        .HasForeignKey("GroupId");

                    b.HasOne("actividad7.Models.User", "Teacher")
                        .WithMany("CourseGroups")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Course");

                    b.Navigation("Group");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("actividad7.Models.CourseUser", b =>
                {
                    b.HasOne("actividad7.Models.Course", "Course")
                        .WithMany("CourseUsers")
                        .HasForeignKey("CourseId");

                    b.HasOne("actividad7.Models.User", "User")
                        .WithMany("CourseUsers")
                        .HasForeignKey("UserId");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("actividad7.Models.User", b =>
                {
                    b.HasOne("actividad7.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("actividad7.Models.Course", b =>
                {
                    b.Navigation("CourseGroups");

                    b.Navigation("CourseUsers");
                });

            modelBuilder.Entity("actividad7.Models.Group", b =>
                {
                    b.Navigation("CourseGroups");
                });

            modelBuilder.Entity("actividad7.Models.Kit", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("actividad7.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("actividad7.Models.User", b =>
                {
                    b.Navigation("CourseGroups");

                    b.Navigation("CourseUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
