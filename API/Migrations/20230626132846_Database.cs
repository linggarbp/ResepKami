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
                    user_id = table.Column<string>(type: "char(5)", nullable: false),
                    username = table.Column<string>(type: "varchar(50)", nullable: false),
                    nm_resep = table.Column<string>(type: "varchar(100)", nullable: false),
                    deskripsi = table.Column<string>(type: "varchar(255)", nullable: false),
                    nm_bahan = table.Column<string>(type: "varchar(255)", nullable: false),
                    jumlah = table.Column<string>(type: "varchar(50)", nullable: false),
                    langkah = table.Column<string>(type: "varchar(255)", nullable: false),
                    wkt_memasak = table.Column<string>(type: "varchar(20)", nullable: false),
                    kesulitan = table.Column<string>(type: "varchar(20)", nullable: false)
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
                name: "tb_request",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    recipe_id = table.Column<string>(type: "char(5)", nullable: false),
                    recipe_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_approved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_request", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_request_tb_recipe_recipe_id",
                        column: x => x.recipe_id,
                        principalTable: "tb_recipe",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_tb_request_recipe_id",
                table: "tb_request",
                column: "recipe_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_user_roles");

            migrationBuilder.DropTable(
                name: "tb_request");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_recipe");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}
