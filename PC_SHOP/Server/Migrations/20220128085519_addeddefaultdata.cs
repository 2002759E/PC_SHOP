using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PC_SHOP.Server.Migrations
{
    public partial class addeddefaultdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "aa1abe37-a433-427f-8f80-c994d79ffc9b", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "ad97caf8-6d81-4498-9ba0-c2d70f869e88", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "87cd59c3-a200-42c3-b4bb-4ac7f780e71c", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAEAtn6kVMUw4Nhe1qrXguyX8ng4dl4Rx5aVcsjA5ckcNqR+j/smDKD6znZZaz+NeC8Q==", null, false, "43d7fb7f-03aa-4b41-af1e-73ab2e46d120", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(6321), new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(6326), "HP", "System" },
                    { 2, "System", new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(6328), new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(6329), "ASUS", "System" },
                    { 3, "System", new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(6330), new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(6331), "AMD", "System" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(1180), new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(1186), "Deskstops", "System" },
                    { 2, "System", new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(1189), new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(1190), "Laptops & Notebooks", "System" },
                    { 3, "System", new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(1191), new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(1192), "Accessories", "System" },
                    { 4, "System", new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(1193), new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(1194), "PC PARTS", "System" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(3677), new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(3681), "Transaction", "System" },
                    { 2, "System", new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(3684), new DateTime(2022, 1, 28, 16, 55, 19, 473, DateTimeKind.Local).AddTicks(3685), "Trade/Swap", "System" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2022, 1, 28, 16, 55, 19, 470, DateTimeKind.Local).AddTicks(2246), new DateTime(2022, 1, 28, 16, 55, 19, 471, DateTimeKind.Local).AddTicks(9777), "Cash", "System" },
                    { 2, "System", new DateTime(2022, 1, 28, 16, 55, 19, 472, DateTimeKind.Local).AddTicks(576), new DateTime(2022, 1, 28, 16, 55, 19, 472, DateTimeKind.Local).AddTicks(580), "DBS", "System" },
                    { 3, "System", new DateTime(2022, 1, 28, 16, 55, 19, 472, DateTimeKind.Local).AddTicks(582), new DateTime(2022, 1, 28, 16, 55, 19, 472, DateTimeKind.Local).AddTicks(583), "POSB", "System" },
                    { 4, "System", new DateTime(2022, 1, 28, 16, 55, 19, 472, DateTimeKind.Local).AddTicks(584), new DateTime(2022, 1, 28, 16, 55, 19, 472, DateTimeKind.Local).AddTicks(585), "MasterCard", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");
        }
    }
}
