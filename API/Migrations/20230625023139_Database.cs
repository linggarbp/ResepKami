using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(5)", nullable: false),
                    username = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_user_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "char(5)", nullable: true),
                    role_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_user_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_user_roles_tb_m_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "tb_m_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_tb_m_user_roles_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "tb_recipe",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(5)", nullable: false),
                    nm_resep = table.Column<string>(type: "varchar(100)", nullable: false),
                    deskripsi = table.Column<string>(type: "varchar(255)", nullable: false),
                    langkah = table.Column<string>(type: "varchar(255)", nullable: false),
                    wkt_persiapan = table.Column<string>(type: "varchar(20)", nullable: false),
                    wkt_memasak = table.Column<string>(type: "varchar(20)", nullable: false),
                    kesulitan = table.Column<string>(type: "varchar(20)", nullable: false),
                    user_id = table.Column<string>(type: "char(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_recipe", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_recipe_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_comment",
                columns: table => new
                {
                    id = table.Column<string>(type: "char(100)", nullable: false),
                    id_recipe = table.Column<string>(type: "char(5)", nullable: false),
                    user_id = table.Column<string>(type: "char(5)", nullable: true),
                    tgl_komentar = table.Column<DateTime>(type: "datetime", nullable: false),
                    isi_komentar = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_comment_tb_recipe_id_recipe",
                        column: x => x.id_recipe,
                        principalTable: "tb_recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_comment_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_ingredient",
                columns: table => new
                {
                    id_bahan = table.Column<string>(type: "char(5)", nullable: false),
                    nm_bahan = table.Column<string>(type: "varchar(255)", nullable: false),
                    jumlah = table.Column<string>(type: "varchar(50)", nullable: false),
                    satuan = table.Column<string>(type: "varchar(50)", nullable: false),
                    id_resep = table.Column<string>(type: "char(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ingredient", x => x.id_bahan);
                    table.ForeignKey(
                        name: "FK_tb_ingredient_tb_recipe_id_resep",
                        column: x => x.id_resep,
                        principalTable: "tb_recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_comment_id_recipe",
                table: "tb_comment",
                column: "id_recipe");

            migrationBuilder.CreateIndex(
                name: "IX_tb_comment_user_id",
                table: "tb_comment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ingredient_id_resep",
                table: "tb_ingredient",
                column: "id_resep");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_user_roles_role_id",
                table: "tb_m_user_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_user_roles_user_id",
                table: "tb_m_user_roles",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_recipe_user_id",
                table: "tb_recipe",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_comment");

            migrationBuilder.DropTable(
                name: "tb_ingredient");

            migrationBuilder.DropTable(
                name: "tb_m_user_roles");

            migrationBuilder.DropTable(
                name: "tb_recipe");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}
