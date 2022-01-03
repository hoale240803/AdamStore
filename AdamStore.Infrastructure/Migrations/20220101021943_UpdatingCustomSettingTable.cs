using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apricot.Infrastructure.Migrations
{
    public partial class UpdatingCustomSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUsers_CustomSetting_CustomSettingId",
                table: "AppUsers");

            migrationBuilder.DropIndex(
                name: "IX_AppUsers_CustomSettingId",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "CustomSettingId",
                table: "AppUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "CustomSetting",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "0927a144-57c3-4b07-b741-d4ae70970a30");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "14b31105-74fe-4d21-bc15-ffc0e0245045", "AQAAAAEAACcQAAAAEGQAJSYEPiOrYTswZAXxiRhCqunu3YxL1MVBKHbPcCUwoxjcMRRWPzs6yMRKxyJwfA==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 1, 1, 9, 19, 42, 474, DateTimeKind.Local).AddTicks(2605));

            migrationBuilder.CreateIndex(
                name: "IX_CustomSetting_UserId",
                table: "CustomSetting",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomSetting_AppUsers_UserId",
                table: "CustomSetting",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomSetting_AppUsers_UserId",
                table: "CustomSetting");

            migrationBuilder.DropIndex(
                name: "IX_CustomSetting_UserId",
                table: "CustomSetting");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CustomSetting");

            migrationBuilder.AddColumn<string>(
                name: "CustomSettingId",
                table: "AppUsers",
                type: "nvarchar(450)",
                nullable: true);

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
    }
}
