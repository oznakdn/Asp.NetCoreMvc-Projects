using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelerBlog.Persistence.Migrations
{
    public partial class PostsSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlagPictures",
                keyColumn: "Id",
                keyValue: new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 7, 52, 45, 870, DateTimeKind.Utc).AddTicks(5323));

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("219e963c-1ae2-4b03-93fe-9cde43df4df6"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 7, 52, 45, 870, DateTimeKind.Utc).AddTicks(5437));

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("8d65f867-353c-4afe-8dcb-be36012fb2f4"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 7, 52, 45, 870, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("e96ecdee-1207-4bc4-a03a-4fb1143b5f6e"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 7, 52, 45, 870, DateTimeKind.Utc).AddTicks(5419));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "ApproveDate", "Content", "EmailAddress", "IsActive", "IsDeleted", "LocationId", "Name", "SendDate", "Title" },
                values: new object[,]
                {
                    { new Guid("65730b92-fa1c-49e4-8c32-4fad8d941540"), null, "Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "john@mail.com", false, false, new Guid("3714d51f-f691-4c53-a815-9a136a6c3821"), "Traveler Boy", new DateTime(2022, 9, 4, 7, 52, 45, 870, DateTimeKind.Utc).AddTicks(5552), "This is Beylerbeyi Sarayi's post title" },
                    { new Guid("84ae7470-0ad0-4bdb-bbc7-e5ff80a70167"), null, "Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "john@mail.com", false, false, new Guid("2db8c9d8-40a1-445c-bd3e-f126cdf49352"), "Traveler Boy", new DateTime(2022, 9, 4, 7, 52, 45, 870, DateTimeKind.Utc).AddTicks(5475), "This is Pamukkale's post title" },
                    { new Guid("87e7af76-4d0d-4c78-bd78-5d275445f647"), null, "Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "john@mail.com", false, false, new Guid("7583ba2d-1c79-48d0-b49d-fc973aa0a808"), "Traveler Boy", new DateTime(2022, 9, 4, 7, 52, 45, 870, DateTimeKind.Utc).AddTicks(5546), "This is Topkapi Sarayi's post title" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("65730b92-fa1c-49e4-8c32-4fad8d941540"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("84ae7470-0ad0-4bdb-bbc7-e5ff80a70167"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("87e7af76-4d0d-4c78-bd78-5d275445f647"));

            migrationBuilder.UpdateData(
                table: "FlagPictures",
                keyColumn: "Id",
                keyValue: new Guid("7e21177b-f8dd-448b-9a42-55e7336b1881"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 7, 28, 23, 601, DateTimeKind.Utc).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("219e963c-1ae2-4b03-93fe-9cde43df4df6"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 7, 28, 23, 601, DateTimeKind.Utc).AddTicks(7814));

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("8d65f867-353c-4afe-8dcb-be36012fb2f4"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 7, 28, 23, 601, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "LocationPictures",
                keyColumn: "Id",
                keyValue: new Guid("e96ecdee-1207-4bc4-a03a-4fb1143b5f6e"),
                column: "CreatedDate",
                value: new DateTime(2022, 9, 4, 7, 28, 23, 601, DateTimeKind.Utc).AddTicks(7779));
        }
    }
}
