﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230625023139_Database")]
    partial class Database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(100)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime")
                        .HasColumnName("tgl_komentar");

                    b.Property<string>("ContentComment")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("isi_komentar");

                    b.Property<string>("RecipeId")
                        .IsRequired()
                        .HasColumnType("char(5)")
                        .HasColumnName("id_recipe");

                    b.Property<string>("UserId")
                        .HasColumnType("char(5)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.HasIndex("UserId");

                    b.ToTable("tb_comment");
                });

            modelBuilder.Entity("API.Models.Ingredient", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(5)")
                        .HasColumnName("id_bahan");

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nm_bahan");

                    b.Property<string>("RecipeId")
                        .HasColumnType("char(5)")
                        .HasColumnName("id_resep");

                    b.Property<string>("Total")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("jumlah");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("satuan");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("tb_ingredient");
                });

            modelBuilder.Entity("API.Models.Recipe", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(5)")
                        .HasColumnName("id");

                    b.Property<string>("CookingTime")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("wkt_memasak");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("deskripsi");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("kesulitan");

                    b.Property<string>("PrepareTime")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("wkt_persiapan");

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nm_resep");

                    b.Property<string>("Step")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("langkah");

                    b.Property<string>("UserId")
                        .HasColumnType("char(5)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tb_recipe");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_m_roles");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(5)")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("tb_user");
                });

            modelBuilder.Entity("API.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("UserId")
                        .HasColumnType("char(5)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("tb_m_user_roles");
                });

            modelBuilder.Entity("API.Models.Comment", b =>
                {
                    b.HasOne("API.Models.Recipe", "Recipe")
                        .WithMany()
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.Ingredient", b =>
                {
                    b.HasOne("API.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("API.Models.Recipe", b =>
                {
                    b.HasOne("API.Models.User", "User")
                        .WithMany("Recipes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.UserRole", b =>
                {
                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("API.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.Recipe", b =>
                {
                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("API.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Recipes");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
