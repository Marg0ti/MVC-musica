using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicAut_HernandezMargot.Migrations
{
    /// <inheritdoc />
    public partial class M0002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a7e6926b-522f-4daa-85ac-c3ea619c50dc", null, "User", "USER" },
                    { "c326bbf9-d236-44ee-9f43-905dea7396a1", null, "Platinum", "PLATINUM" },
                    { "ca9f92c9-d2d6-4192-bcde-3e9e10f47aab", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3fc7cf0c-a849-4e43-a5f3-4a6d71c27e6a", 0, "446e09ba-5b73-492b-8a8a-3d1c2bb635c6", "user@chinook.com", true, false, null, "USER@CHINOOK.COM", "USER@CHINOOK.COM", "AQAAAAIAAYagAAAAEG2LGal4CyrkbZsCEPkvReTlgtnpgPF/TFH9BMDwQb+i7GQRDIhufjtgvchEClwsOw==", null, false, "d580360b-0fa5-42e3-9da8-1b444120495a", false, "user@chinook.com" },
                    { "9442c75f-2773-4a1a-91be-1e6d2ae5915c", 0, "1deffa80-040f-4a81-8368-0984b2ed93e7", "admin@chinook.com", true, false, null, "ADMIN@CHINOOK.COM", "ADMIN@CHINOOK.COM", "AQAAAAIAAYagAAAAENx0KPWT5H/RpEpl6hhTTH9OJznf7+yKZ1BOsIBHrGEe7mWqvKjIKmliCUIpVXBiKg==", null, false, "dd5e6bb0-3f85-4931-ac6f-3354fe6cfcd6", false, "admin@chinook.com" },
                    { "ba0eea96-02e7-48c5-b9a0-45847e716c21", 0, "8ad70228-1d2e-4027-8618-57dbf6123a18", "platinum@chinook.com", true, false, null, "PLATINUM@CHINOOK.COM", "PLATINUM@CHINOOK.COM", "AQAAAAIAAYagAAAAEGdWuhTXYHdWjHzhbwuLedN72gGiLx/NI2z7xso8+mOGgIW/zLlpIKN+sPTEJDwnMQ==", null, false, "3e93e2d5-ebb0-4dcb-ac89-0a2f9b4e6121", false, "platinum@chinook.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a7e6926b-522f-4daa-85ac-c3ea619c50dc", "3fc7cf0c-a849-4e43-a5f3-4a6d71c27e6a" },
                    { "ca9f92c9-d2d6-4192-bcde-3e9e10f47aab", "9442c75f-2773-4a1a-91be-1e6d2ae5915c" },
                    { "c326bbf9-d236-44ee-9f43-905dea7396a1", "ba0eea96-02e7-48c5-b9a0-45847e716c21" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a7e6926b-522f-4daa-85ac-c3ea619c50dc", "3fc7cf0c-a849-4e43-a5f3-4a6d71c27e6a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ca9f92c9-d2d6-4192-bcde-3e9e10f47aab", "9442c75f-2773-4a1a-91be-1e6d2ae5915c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c326bbf9-d236-44ee-9f43-905dea7396a1", "ba0eea96-02e7-48c5-b9a0-45847e716c21" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7e6926b-522f-4daa-85ac-c3ea619c50dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c326bbf9-d236-44ee-9f43-905dea7396a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca9f92c9-d2d6-4192-bcde-3e9e10f47aab");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fc7cf0c-a849-4e43-a5f3-4a6d71c27e6a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9442c75f-2773-4a1a-91be-1e6d2ae5915c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba0eea96-02e7-48c5-b9a0-45847e716c21");

     
        }
    }
}
