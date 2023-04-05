using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationCoreGLSID.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesToProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produits_Images_ImageProduitId",
                table: "produits");

            migrationBuilder.DropIndex(
                name: "IX_produits_ImageProduitId",
                table: "produits");

            migrationBuilder.DropColumn(
                name: "ImageProduitId",
                table: "produits");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAjoutProduit",
                table: "produits",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "produits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "produitId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_produitId",
                table: "Images",
                column: "produitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_produits_produitId",
                table: "Images",
                column: "produitId",
                principalTable: "produits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_produits_produitId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_produitId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DateAjoutProduit",
                table: "produits");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "produits");

            migrationBuilder.DropColumn(
                name: "produitId",
                table: "Images");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageProduitId",
                table: "produits",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_produits_ImageProduitId",
                table: "produits",
                column: "ImageProduitId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_produits_Images_ImageProduitId",
                table: "produits",
                column: "ImageProduitId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
