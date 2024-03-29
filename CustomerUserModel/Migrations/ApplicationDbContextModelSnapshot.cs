﻿// <auto-generated />
using System;
using CustomerUserModel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerUserModel.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("Cat_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cat_Id"));

                    b.Property<int>("Cat_Fk_Ad")
                        .HasColumnType("int");

                    b.Property<string>("Cat_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cat_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Cat_Status")
                        .HasColumnType("int");

                    b.HasKey("Cat_Id");

                    b.HasIndex("Cat_Fk_Ad");

                    b.ToTable("tbl_Category");
                });

            modelBuilder.Entity("CustomerUserModel.Models.Udemy.Admin", b =>
                {
                    b.Property<int>("ad_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ad_id"));

                    b.Property<string>("ad_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ad_userName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ad_id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<int>("Pro_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Pro_Id"));

                    b.Property<string>("Pro_Category")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pro_Des")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Pro_Fk_Cat")
                        .HasColumnType("int");

                    b.Property<int>("Pro_Fk_User")
                        .HasColumnType("int");

                    b.Property<string>("Pro_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Pro_Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("UsserU_Id")
                        .HasColumnType("int");

                    b.HasKey("Pro_Id");

                    b.HasIndex("Pro_Fk_Cat");

                    b.HasIndex("UsserU_Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("U_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("U_Id"));

                    b.Property<string>("U_Contact")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("U_Department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("U_Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("U_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("U_Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("U_Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("U_Id");

                    b.ToTable("tbl_User");
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.HasOne("CustomerUserModel.Models.Udemy.Admin", "Admin")
                        .WithMany("Categories")
                        .HasForeignKey("Cat_Fk_Ad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.HasOne("Category", "Category")
                        .WithMany()
                        .HasForeignKey("Pro_Fk_Cat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "Usser")
                        .WithMany()
                        .HasForeignKey("UsserU_Id");

                    b.Navigation("Category");

                    b.Navigation("Usser");
                });

            modelBuilder.Entity("CustomerUserModel.Models.Udemy.Admin", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
