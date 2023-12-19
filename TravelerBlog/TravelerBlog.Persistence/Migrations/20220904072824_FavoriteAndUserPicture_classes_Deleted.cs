using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelerBlog.Persistence.Migrations
{
    public partial class FavoriteAndUserPicture_classes_Deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advices_AspNetUsers_UserId1",
                table: "Advices");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_UserId1",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "UserPictures");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId1",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Advices_UserId1",
                table: "Advices");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Advices");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Advices");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Advices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Advices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "FlagPictures",
                columns: new[] { "Id", "CreatedDate", "Description", "FileName", "IsActive", "IsDeleted" },
                values: new object[] { new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"), new DateTime(2022, 9, 4, 7, 28, 23, 601, DateTimeKind.Utc).AddTicks(7703), null, "https://www.kitapgunu.com/u/kitapgunu/img/c/t/u/turk-bayragi-200x300cma8781fddae7a2d3d55e9dc27dfd4e861.jpg", true, false });

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("8d65f867-353c-4afe-8dcb-be36012fb2f4"),
                columns: new[] { "CreatedDate", "FileName" },
                values: new object[] { new DateTime(2022, 9, 4, 7, 28, 23, 601, DateTimeKind.Utc).AddTicks(7810), "https://i4.hurimg.com/i/hurriyet/75/1110x740/5bc6d94218c773222c635a60.jpg" });

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("e96ecdee-1207-4bc4-a03a-4fb1143b5f6e"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 7, 28, 23, 601, DateTimeKind.Utc).AddTicks(7779));

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "CountryId", "Description", "Ditrict", "IsActive", "IsDeleted", "LocationName" },
                values: new object[] { new Guid("3714d51f-f691-4c53-a815-9a136a6c3821"), "Istanbul", new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"), "Beylerbeyi Sarayı, İstanbul'un Üsküdar ilçesinin Beylerbeyi semtinde bulunan ve Sultan Abdülaziz tarafından 1861-1865 yıllarında mimar Sarkis Balyan'a yaptırılan saraydır.", "Uskudar", true, false, "Beylerbeyi Sarayi" });

            migrationBuilder.InsertData(
                table: "LocationPictures",
                columns: new[] { "Id", "CreatedDate", "Description", "FileName", "IsActive", "IsDeleted", "LocationId" },
                values: new object[] { new Guid("219e963c-1ae2-4b03-93fe-9cde43df4df6"), new DateTime(2022, 9, 4, 7, 28, 23, 601, DateTimeKind.Utc).AddTicks(7814), null, "https://istanbeautiful.com/tr/wp-content/uploads/beylerbeyi-palace.jpg", true, false, new Guid("3714d51f-f691-4c53-a815-9a136a6c3821") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FlagPictures",
                keyColumn: "Id",
                keyValue: new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"));

            migrationBuilder.DeleteData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("219e963c-1ae2-4b03-93fe-9cde43df4df6"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("3714d51f-f691-4c53-a815-9a136a6c3821"));

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Advices");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Advices");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Posts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Advices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Advices",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Favorites_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPictures_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("8d65f867-353c-4afe-8dcb-be36012fb2f4"),
                columns: new[] { "CreatedDate", "FileName" },
                values: new object[] { new DateTime(2022, 9, 3, 10, 7, 34, 407, DateTimeKind.Utc).AddTicks(4442), "https://muzeler.org/images/google-place-images/topkapi-sarayi-muzesi.jpg" });

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("e96ecdee-1207-4bc4-a03a-4fb1143b5f6e"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 3, 10, 7, 34, 407, DateTimeKind.Utc).AddTicks(4432));

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId1",
                table: "Posts",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Advices_UserId1",
                table: "Advices",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_LocationId",
                table: "Favorites",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId1",
                table: "Favorites",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserPictures_UserId",
                table: "UserPictures",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Advices_AspNetUsers_UserId1",
                table: "Advices",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_UserId1",
                table: "Posts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
