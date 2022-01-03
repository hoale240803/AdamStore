using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apricot.Infrastructure.Migrations
{
    public partial class addrefreshtokenfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AppUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"),
                column: "ConcurrencyStamp",
                value: "bc83e337-40cc-47a8-b75d-1015004bade9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"),
                column: "ConcurrencyStamp",
                value: "69a2ed2e-e2ac-44f5-a3e4-302070fa45bf");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"),
                column: "ConcurrencyStamp",
                value: "9e19443b-54be-49c2-8a83-1b4d3a21f65e");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"),
                column: "ConcurrencyStamp",
                value: "b2d5513c-69b3-474c-8611-cf5ebaabbe95");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c4be633f-9a9b-4070-88ec-97ef9b444542", "AQAAAAEAACcQAAAAEKq5x5ZKtNWAtfm74EwocXjzDEfkJ14Mo/xsEADtLX/YyHsXFXHiisOAGmDL/zn+QQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a174e6aa-ccb8-4c69-888f-972e785eba0d", "AQAAAAEAACcQAAAAENmZAzpMPrueuUPh7MnXGfiXbdGLvSqC2l+1Sg85mHUAGbC+3vDeludzhkPwerd93w==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f020cf0b-553e-433f-bbbb-f32b8c1c289d", "AQAAAAEAACcQAAAAEAgu3GeXAqP5BKKoufcZXvUYcnVVrcpsVboH2PFJw3BHON3GsF+LoXylKg0mxVmMIQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d48d3fdb-10f4-4d5e-91f7-69521359defb", "AQAAAAEAACcQAAAAEGxpjwr35rPuT7kPuphO7xFrmMHFMfi0LlEmtABpzd7zJqj3wPdnnJmuUeCz/I1uCw==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 1, 4, 0, 40, 47, 32, DateTimeKind.Local).AddTicks(5117));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"),
                column: "ConcurrencyStamp",
                value: "9f9f8998-86dc-48b7-bb9c-bf224ba1098a");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"),
                column: "ConcurrencyStamp",
                value: "2a23ee91-8776-4f2d-96e8-ca32483b342a");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"),
                column: "ConcurrencyStamp",
                value: "497b8d19-ddb9-4ff3-903b-1a71a33f6dac");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"),
                column: "ConcurrencyStamp",
                value: "87d13326-83fe-4c3f-8e91-eb78b3423821");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d69a69f3-2910-485b-aa6c-056525e983e0", "AQAAAAEAACcQAAAAEBbmOLDm3FT+iaqWfVB4pY0gGkvusQZqr1FJLQiiM9BJoCEe945N/p6DvrSA7xcFmw==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "34388c06-9d0e-454a-96cb-c8b9c5a9e7e5", "AQAAAAEAACcQAAAAEMCTB/yxe1AvPlN+6wZB6uA0SOBBiaRbN3idA0l9FINEJMCdW3z+5bKaKcgZvp9jaQ==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a996e11e-1e53-472e-a236-b41026fc0690", "AQAAAAEAACcQAAAAENO0IqPh6WUMXWvBTpga5/uW1vpk9eDaHkl9NI1CPSPI89ud6hHMnjf+pmpIsKFJ0g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f773cf13-c7de-4e77-9555-d90f77239042", "AQAAAAEAACcQAAAAEJE6tmxAfbqwGRMXXGvjF+AIcIzBgjRuZpnlVZZM6Euq9vei7T4CKMnoOFilLkibSg==" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 1, 3, 23, 11, 58, 677, DateTimeKind.Local).AddTicks(4685));
        }
    }
}
