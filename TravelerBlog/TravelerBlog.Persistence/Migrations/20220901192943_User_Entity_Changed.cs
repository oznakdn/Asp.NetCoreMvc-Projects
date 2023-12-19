using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelerBlog.Persistence.Migrations
{
    public partial class User_Entity_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_LocationPictures_PictureId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPictures_AspNetUsers_UserId1",
                table: "UserPictures");

            migrationBuilder.DropIndex(
                name: "IX_UserPictures_UserId1",
                table: "UserPictures");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PictureId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UserPictures");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserPictures",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_UserPictures_UserId",
                table: "UserPictures",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPictures_AspNetUsers_UserId",
                table: "UserPictures",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPictures_AspNetUsers_UserId",
                table: "UserPictures");

            migrationBuilder.DropIndex(
                name: "IX_UserPictures_UserId",
                table: "UserPictures");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserPictures",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "UserPictures",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PictureId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPictures_UserId1",
                table: "UserPictures",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PictureId",
                table: "AspNetUsers",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_LocationPictures_PictureId",
                table: "AspNetUsers",
                column: "PictureId",
                principalTable: "LocationPictures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPictures_AspNetUsers_UserId1",
                table: "UserPictures",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
