using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelerBlog.Persistence.Migrations
{
    public partial class City_Entity_Deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Cities_CityId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Locations",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                newName: "IX_Locations_CountryId");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ditrict",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName", "Description", "IsDeleted" },
                values: new object[] { new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"), "Turkey", "Turkey,[a] officially the Republic of Türkiye,[b] is a transcontinental country located mainly on the Anatolian Peninsula in Western Asia, with a small portion on the Balkan Peninsula in Southeast Europe. It shares borders with the Black Sea to the north; Georgia to the northeast; Armenia, Azerbaijan, and Iran to the east; Iraq to the southeast; Syria and the Mediterranean Sea to the south; the Aegean Sea to the west; and Greece and Bulgaria to the northwest. Cyprus is located off the south coast. Turks form the vast majority of the nation's population and Kurds are the largest minority.[4] Ankara is Turkey's capital, while Istanbul is its largest city and financial centre.", false });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "CountryId", "Description", "Ditrict", "IsActive", "IsDeleted", "LocationName" },
                values: new object[] { new Guid("2db8c9d8-40a1-445c-bd3e-f126cdf49352"), "Denizli", new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"), "Kent Kaplıcaları ve akan sulardan kalan karbonat minerallerin teraslarını, travertenlerini kapsamaktadır.", "", true, false, "Pamukkale" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "CountryId", "Description", "Ditrict", "IsActive", "IsDeleted", "LocationName" },
                values: new object[] { new Guid("7583ba2d-1c79-48d0-b49d-fc973aa0a808"), "Istanbul", new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"), "Topkapı Sarayı, İstanbul Sarayburnu'nda, Osmanlı İmparatorluğu'nun 600 yıllık tarihinin 400 yılı boyunca, devletin idare merkezi olarak kullanılan ve Osmanlı padişahlarının yaşadığı saraydır. ", "Fatih", true, false, "Topkapi Sarayi" });

            migrationBuilder.InsertData(
                table: "LocationPictures",
                columns: new[] { "Id", "CreatedDate", "Description", "FileName", "IsActive", "IsDeleted", "LocationId" },
                values: new object[] { new Guid("8d65f867-353c-4afe-8dcb-be36012fb2f4"), new DateTime(2022, 9, 3, 10, 7, 34, 407, DateTimeKind.Utc).AddTicks(4442), null, "https://muzeler.org/images/google-place-images/topkapi-sarayi-muzesi.jpg", true, false, new Guid("7583ba2d-1c79-48d0-b49d-fc973aa0a808") });

            migrationBuilder.InsertData(
                table: "LocationPictures",
                columns: new[] { "Id", "CreatedDate", "Description", "FileName", "IsActive", "IsDeleted", "LocationId" },
                values: new object[] { new Guid("e96ecdee-1207-4bc4-a03a-4fb1143b5f6e"), new DateTime(2022, 9, 3, 10, 7, 34, 407, DateTimeKind.Utc).AddTicks(4432), null, "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c6/Pamukkale_02.jpg/1280px-Pamukkale_02.jpg", true, false, new Guid("2db8c9d8-40a1-445c-bd3e-f126cdf49352") });

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Countries_CountryId",
                table: "Locations");

            migrationBuilder.DeleteData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("8d65f867-353c-4afe-8dcb-be36012fb2f4"));

            migrationBuilder.DeleteData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("e96ecdee-1207-4bc4-a03a-4fb1143b5f6e"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("2db8c9d8-40a1-445c-bd3e-f126cdf49352"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("7583ba2d-1c79-48d0-b49d-fc973aa0a808"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"));

            migrationBuilder.DropColumn(
                name: "City",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Ditrict",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Locations",
                newName: "CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                newName: "IX_Locations_CityId");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Cities_CityId",
                table: "Locations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
