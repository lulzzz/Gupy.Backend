using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gupy.Data.Migrations
{
    public partial class RemovePromotionEntityConfigChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderitems_Orders_OrderId",
                table: "orderitems");

            migrationBuilder.DropForeignKey(
                name: "FK_orderitems_Products_ProductId",
                table: "orderitems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_promotions_PromotionId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "promotions");

            migrationBuilder.DropIndex(
                name: "IX_Products_PromotionId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderitems",
                table: "orderitems");

            migrationBuilder.DropColumn(
                name: "PromotionId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "orderitems",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_orderitems_ProductId",
                table: "OrderItems",
                newName: "IX_OrderItems_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TelegramUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverName",
                table: "ShippingDetails",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256) CHARACTER SET utf8mb4",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ShippingDetails",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(64) CHARACTER SET utf8mb4",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "ShippingDetails",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256) CHARACTER SET utf8mb4",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PromotionEndDate",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PromotionPrice",
                table: "Products",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "PromotionEndDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PromotionPrice",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "orderitems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_ProductId",
                table: "orderitems",
                newName: "IX_orderitems_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "TelegramUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ReceiverName",
                table: "ShippingDetails",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ShippingDetails",
                type: "varchar(64) CHARACTER SET utf8mb4",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "ShippingDetails",
                type: "varchar(256) CHARACTER SET utf8mb4",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "PromotionId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderitems",
                table: "orderitems",
                columns: new[] { "OrderId", "ProductId" });

            migrationBuilder.CreateTable(
                name: "promotions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(type: "varchar(256) CHARACTER SET utf8mb4", maxLength: 256, nullable: true),
                    Price = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_promotions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PromotionId",
                table: "Products",
                column: "PromotionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_orderitems_Orders_OrderId",
                table: "orderitems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderitems_Products_ProductId",
                table: "orderitems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_promotions_PromotionId",
                table: "Products",
                column: "PromotionId",
                principalTable: "promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
