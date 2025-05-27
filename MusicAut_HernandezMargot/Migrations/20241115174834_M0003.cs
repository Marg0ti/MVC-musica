using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicAut_HernandezMargot.Migrations
{
    /// <inheritdoc />
    public partial class M0003 : Migration
    {

            /// <inheritdoc />
            protected override void Up(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropForeignKey(
                    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                    table: "AspNetUserRoles");

                migrationBuilder.AddForeignKey(
                    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                    table: "AspNetUserRoles",
                    column: "UserId",
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            }

            protected override void Down(MigrationBuilder migrationBuilder)
            {
                migrationBuilder.DropForeignKey(
                    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                    table: "AspNetUserRoles");

                migrationBuilder.AddForeignKey(
                    name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                    table: "AspNetUserRoles",
                    column: "UserId",
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict);
            }
        
    }

}
