using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSID.Migrations
{
    /// <inheritdoc />
    public partial class TestAPIFluent4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProduitSsCategs",
                columns: table => new
                {
                    SousCategorieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    produitsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitSsCategs", x => new { x.SousCategorieId, x.produitsId });
                    table.ForeignKey(
                        name: "FK_ProduitSsCategs_produits_produitsId",
                        column: x => x.produitsId,
                        principalTable: "produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduitSsCategs_sscategories_SousCategorieId",
                        column: x => x.SousCategorieId,
                        principalTable: "sscategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProduitSsCategs_produitsId",
                table: "ProduitSsCategs",
                column: "produitsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduitSsCategs");

            migrationBuilder.DropTable(
                name: "produits");
        }
    }
}
