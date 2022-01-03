using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apricot.Infrastructure.Migrations
{
    public partial class AddingCustomSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomSettingId",
                table: "AppUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomSetting",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThemeColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Font = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomSetting", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "28cd7ef4-5182-4d92-a2d1-fcc9298ba9be");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1476d4f7-c5ba-4a6a-9b4d-ea1901119cc3", "AQAAAAEAACcQAAAAELf1PPn1zMQ7HQTVyK3oHNzpSrqXpgWZAHtdoxp9neQDtGATpW2PeHAKOi8RpSOknw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 1, 1, 9, 1, 22, 365, DateTimeKind.Local).AddTicks(6927));

            migrationBuilder.CreateIndex(
                name: "IX_AppUsers_CustomSettingId",
                table: "AppUsers",
                column: "CustomSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUsers_CustomSetting_CustomSettingId",
                table: "AppUsers",
                column: "CustomSettingId",
                principalTable: "CustomSetting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_CustomSetting_CustomSettingId",
                table: "AppUsers");

            migrationBuilder.DropTable(
                name: "CustomSetting");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_CustomSettingId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CustomSettingId",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "b368c7cf-7f56-4307-9557-e38aff74c11f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fcd57f3c-3b15-4343-be25-ac742302d5cf", "AQAAAAEAACcQAAAAEL0rhPKpe3jfOCEvHwvxGgWvBmhFWIu1uH2ImkHvpqGozRmPKNQ3s78jp5FbYSZT3w==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 1, 1, 8, 56, 21, 632, DateTimeKind.Local).AddTicks(7828));
        }
    }
}
