using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apricot.Infrastructure.Migrations
{
    public partial class seedUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"), "9f9f8998-86dc-48b7-bb9c-bf224ba1098a", "Administrator role", "admin", "admin" },
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"), "2a23ee91-8776-4f2d-96e8-ca32483b342a", "Manager role", "manager", "manager" },
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"), "497b8d19-ddb9-4ff3-903b-1a71a33f6dac", "User role", "user", "user" },
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"), "87d13326-83fe-4c3f-8e91-eb78b3423821", "Visitor role", "visitor", "visitor" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"), new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b") },
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"), new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c") },
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"), new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d") },
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"), new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e") }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"), 0, "d69a69f3-2910-485b-aa6c-056525e983e0", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "lehoa08121998@gmail.com", true, "Hoa", "Le", false, null, "lehoa08121998@gmail.com", "admin", "AQAAAAEAACcQAAAAEBbmOLDm3FT+iaqWfVB4pY0gGkvusQZqr1FJLQiiM9BJoCEe945N/p6DvrSA7xcFmw==", null, false, "", false, "admin" },
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"), 0, "34388c06-9d0e-454a-96cb-c8b9c5a9e7e5", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoamanager@yopmail.com", true, "Hoa Manager", "Le", false, null, "hoamanager@yopmail.com", "manager", "AQAAAAEAACcQAAAAEMCTB/yxe1AvPlN+6wZB6uA0SOBBiaRbN3idA0l9FINEJMCdW3z+5bKaKcgZvp9jaQ==", null, false, "", false, "manager" },
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"), 0, "a996e11e-1e53-472e-a236-b41026fc0690", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoauser@yopmail.com", true, "Hoa User", "Le", false, null, "hoauser@yopmail.com", "user", "AQAAAAEAACcQAAAAENO0IqPh6WUMXWvBTpga5/uW1vpk9eDaHkl9NI1CPSPI89ud6hHMnjf+pmpIsKFJ0g==", null, false, "", false, "user" },
                    { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"), 0, "f773cf13-c7de-4e77-9555-d90f77239042", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "hoavisitor@yopmail.com", true, "Hoa Visitor", "Le", false, null, "hoavisitor@yopmail.com", "visitor", "AQAAAAEAACcQAAAAEJE6tmxAfbqwGRMXXGvjF+AIcIzBgjRuZpnlVZZM6Euq9vei7T4CKMnoOFilLkibSg==", null, false, "", false, "visitor" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 1, 3, 23, 11, 58, 677, DateTimeKind.Local).AddTicks(4685));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"), new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"), new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"), new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"), new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d"));

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e"));

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), "0927a144-57c3-4b07-b741-d4ae70970a30", "Administrator role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"), new Guid("69bd714f-9576-45ba-b5b7-f00649be00de") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"), 0, "14b31105-74fe-4d21-bc15-ffc0e0245045", new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "tedu.international@gmail.com", true, "Toan", "Bach", false, null, "tedu.international@gmail.com", "admin", "AQAAAAEAACcQAAAAEGQAJSYEPiOrYTswZAXxiRhCqunu3YxL1MVBKHbPcCUwoxjcMRRWPzs6yMRKxyJwfA==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2022, 1, 1, 9, 19, 42, 474, DateTimeKind.Local).AddTicks(2605));
        }
    }
}
