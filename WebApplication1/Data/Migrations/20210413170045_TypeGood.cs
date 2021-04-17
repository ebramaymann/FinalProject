using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Data.Migrations
{
    public partial class TypeGood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_Offer_IdoffersNavigationId",
                table: "Good");

            migrationBuilder.DropForeignKey(
                name: "FK_Good_TypeGood_IdtgNavigationId",
                table: "Good");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_TypeGood_IdtyGNavigationId",
                table: "Offer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeGood",
                table: "TypeGood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offer",
                table: "Offer");

            migrationBuilder.RenameTable(
                name: "TypeGood",
                newName: "typeGoods");

            migrationBuilder.RenameTable(
                name: "Offer",
                newName: "Offers");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_IdtyGNavigationId",
                table: "Offers",
                newName: "IX_Offers_IdtyGNavigationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_typeGoods",
                table: "typeGoods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_Offers_IdoffersNavigationId",
                table: "Good",
                column: "IdoffersNavigationId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Good_typeGoods_IdtgNavigationId",
                table: "Good",
                column: "IdtgNavigationId",
                principalTable: "typeGoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_typeGoods_IdtyGNavigationId",
                table: "Offers",
                column: "IdtyGNavigationId",
                principalTable: "typeGoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Good_Offers_IdoffersNavigationId",
                table: "Good");

            migrationBuilder.DropForeignKey(
                name: "FK_Good_typeGoods_IdtgNavigationId",
                table: "Good");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_typeGoods_IdtyGNavigationId",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_typeGoods",
                table: "typeGoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.RenameTable(
                name: "typeGoods",
                newName: "TypeGood");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "Offer");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_IdtyGNavigationId",
                table: "Offer",
                newName: "IX_Offer_IdtyGNavigationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeGood",
                table: "TypeGood",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offer",
                table: "Offer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Good_Offer_IdoffersNavigationId",
                table: "Good",
                column: "IdoffersNavigationId",
                principalTable: "Offer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Good_TypeGood_IdtgNavigationId",
                table: "Good",
                column: "IdtgNavigationId",
                principalTable: "TypeGood",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_TypeGood_IdtyGNavigationId",
                table: "Offer",
                column: "IdtyGNavigationId",
                principalTable: "TypeGood",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
