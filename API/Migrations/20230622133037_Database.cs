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
                name: "Comments",
                columns: table => new
                {
                    id_komen = table.Column<string>(type: "char(100)", nullable: false),
                    tgl_komentar = table.Column<DateTime>(type: "datetime", nullable: false),
                    isi_komentar = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id_komen);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    id_bahan = table.Column<string>(type: "varchar(100)", nullable: false),
                    nm_bahan = table.Column<string>(type: "varchar(100)", nullable: false),
                    jumlah = table.Column<string>(type: "varchar(255)", nullable: false),
                    satuan = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.id_bahan);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_recipe",
                columns: table => new
                {
                    id_recipe = table.Column<string>(type: "varchar(100)", nullable: false),
                    nm_resep = table.Column<string>(type: "varchar(100)", nullable: false),
                    deskripsi = table.Column<string>(type: "varchar(255)", nullable: false),
                    bahan = table.Column<string>(type: "varchar(255)", nullable: false),
                    langkah = table.Column<string>(type: "varchar(255)", nullable: false),
                    wkt_persiapan = table.Column<string>(type: "varchar(20)", nullable: false),
                    wkt_memasak = table.Column<string>(type: "varchar(20)", nullable: false),
                    kesulitan = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_recipe", x => x.id_recipe);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "char(5", nullable: false),
                    user_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.user_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "tb_m_recipe");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}
