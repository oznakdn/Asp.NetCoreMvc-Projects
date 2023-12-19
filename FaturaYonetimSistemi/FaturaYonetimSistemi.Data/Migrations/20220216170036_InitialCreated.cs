using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FaturaYonetimSistemi.Data.Migrations
{
    public partial class InitialCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aidatlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Donem = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SonOdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aidatlar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bloklar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlokAdi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ToplamDaire = table.Column<short>(type: "smallint", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloklar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Faturalar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SonOdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FaturaAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturalar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Daireler",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaireNo = table.Column<short>(type: "smallint", nullable: false),
                    Kat = table.Column<short>(type: "smallint", nullable: false),
                    BosMu = table.Column<bool>(type: "bit", nullable: false),
                    Tipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SahibiMi = table.Column<bool>(type: "bit", nullable: true),
                    Blokid = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daireler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Daireler_Bloklar_Blokid",
                        column: x => x.Blokid,
                        principalTable: "Bloklar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TCNo = table.Column<long>(type: "bigint", nullable: false),
                    Fotograf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Arac = table.Column<bool>(type: "bit", nullable: false),
                    Plaka = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DaireId = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Daireler_DaireId",
                        column: x => x.DaireId,
                        principalTable: "Daireler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciAidatlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    AidatId = table.Column<int>(type: "int", nullable: false),
                    OdendiMi = table.Column<bool>(type: "bit", nullable: false),
                    OdenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciAidatlar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KullaniciAidatlar_Aidatlar_AidatId",
                        column: x => x.AidatId,
                        principalTable: "Aidatlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciAidatlar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciFaturalar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    FaturaId = table.Column<int>(type: "int", nullable: false),
                    OdendiMi = table.Column<bool>(type: "bit", nullable: false),
                    OdemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciFaturalar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KullaniciFaturalar_Faturalar_FaturaId",
                        column: x => x.FaturaId,
                        principalTable: "Faturalar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciFaturalar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesajlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Konu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Icerik = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    OlusturmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesajlar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mesajlar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aidatlar",
                columns: new[] { "ID", "Aciklama", "AktifMi", "Donem", "GuncellemeTarihi", "OlusturmaTarihi", "SonOdemeTarihi", "Tutar" },
                values: new object[,]
                {
                    { 1, "Ocak ayı bina tadilat masrafı eklenmiştir.", true, "Ocak 2022", new DateTime(2022, 2, 16, 20, 0, 35, 896, DateTimeKind.Local).AddTicks(1096), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m },
                    { 2, "Ocak ayı bina tadilat masrafı eklenmiştir.", true, "Şubat 2022", new DateTime(2022, 2, 16, 20, 0, 35, 896, DateTimeKind.Local).AddTicks(1110), new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m }
                });

            migrationBuilder.InsertData(
                table: "Bloklar",
                columns: new[] { "ID", "AktifMi", "BlokAdi", "GuncellemeTarihi", "OlusturmaTarihi", "ToplamDaire" },
                values: new object[] { 1, true, "A Blok", new DateTime(2022, 2, 16, 20, 0, 35, 890, DateTimeKind.Local).AddTicks(8988), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)20 });

            migrationBuilder.InsertData(
                table: "Faturalar",
                columns: new[] { "ID", "Aciklama", "AktifMi", "FaturaAdi", "GuncellemeTarihi", "OlusturmaTarihi", "SonOdemeTarihi", "Tutar" },
                values: new object[,]
                {
                    { 1, "Şubat 2022 elektrik faturası", true, "Elektrik", new DateTime(2022, 2, 16, 20, 0, 35, 897, DateTimeKind.Local).AddTicks(7851), new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m },
                    { 2, "Şubat 2022 su faturası", true, "Su", new DateTime(2022, 2, 16, 20, 0, 35, 897, DateTimeKind.Local).AddTicks(7863), new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m }
                });

            migrationBuilder.InsertData(
                table: "Daireler",
                columns: new[] { "ID", "AktifMi", "Blokid", "BosMu", "DaireNo", "GuncellemeTarihi", "Kat", "OlusturmaTarihi", "SahibiMi", "Tipi" },
                values: new object[,]
                {
                    { 1, true, 1, false, (short)1, new DateTime(2022, 2, 16, 20, 0, 35, 887, DateTimeKind.Local).AddTicks(4423), (short)1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "3+1" },
                    { 2, true, 1, true, (short)2, new DateTime(2022, 2, 16, 20, 0, 35, 887, DateTimeKind.Local).AddTicks(5382), (short)1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "2+1" },
                    { 3, true, 1, false, (short)3, new DateTime(2022, 2, 16, 20, 0, 35, 887, DateTimeKind.Local).AddTicks(5387), (short)2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "3+1" },
                    { 4, true, 1, true, (short)4, new DateTime(2022, 2, 16, 20, 0, 35, 887, DateTimeKind.Local).AddTicks(5391), (short)2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "2+1" }
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "ID", "Ad", "AktifMi", "Arac", "DaireId", "Email", "Fotograf", "GuncellemeTarihi", "OlusturmaTarihi", "Plaka", "Soyad", "TCNo", "Telefon" },
                values: new object[] { 1, "Ali", true, false, 1, "aliguzel@mail.com", "https://statics.altinyildizclassics.com/mnresize/380/521/productimages/4A3022100062_LAM_1.jpg", new DateTime(2022, 2, 16, 20, 0, 35, 893, DateTimeKind.Local).AddTicks(8009), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Güzel", 12345678910L, "05001002030" });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "ID", "Ad", "AktifMi", "Arac", "DaireId", "Email", "Fotograf", "GuncellemeTarihi", "OlusturmaTarihi", "Plaka", "Soyad", "TCNo", "Telefon" },
                values: new object[] { 2, "Veli", true, true, 3, "velisever@mail.com", "https://cdn.sorsware.com/ramsey/ContentImages/Product/2019-1/10112785/duz-dokuma-ceket_lacivert-lacivert_1_buyuk.JPG", new DateTime(2022, 2, 16, 20, 0, 35, 893, DateTimeKind.Local).AddTicks(8028), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "34 ABC 100", "Sever", 10987654321L, "05002003040" });

            migrationBuilder.InsertData(
                table: "KullaniciAidatlar",
                columns: new[] { "ID", "AidatId", "AktifMi", "GuncellemeTarihi", "KullaniciId", "OdendiMi", "OdenmeTarihi", "OlusturmaTarihi" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2022, 2, 16, 20, 0, 35, 899, DateTimeKind.Local).AddTicks(3044), 1, false, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, true, new DateTime(2022, 2, 16, 20, 0, 35, 899, DateTimeKind.Local).AddTicks(3058), 1, false, null, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, true, new DateTime(2022, 2, 16, 20, 0, 35, 899, DateTimeKind.Local).AddTicks(3062), 2, false, null, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, true, new DateTime(2022, 2, 16, 20, 0, 35, 899, DateTimeKind.Local).AddTicks(3065), 2, false, null, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "KullaniciFaturalar",
                columns: new[] { "ID", "AktifMi", "FaturaId", "GuncellemeTarihi", "KullaniciId", "OdemeTarihi", "OdendiMi", "OlusturmaTarihi" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2022, 2, 16, 20, 0, 35, 900, DateTimeKind.Local).AddTicks(8247), 1, null, false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, 2, new DateTime(2022, 2, 16, 20, 0, 35, 900, DateTimeKind.Local).AddTicks(8260), 1, null, false, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, 1, new DateTime(2022, 2, 16, 20, 0, 35, 900, DateTimeKind.Local).AddTicks(8275), 2, null, false, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, true, 2, new DateTime(2022, 2, 16, 20, 0, 35, 900, DateTimeKind.Local).AddTicks(8279), 2, null, false, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Mesajlar",
                columns: new[] { "ID", "AktifMi", "GuncellemeTarihi", "Icerik", "Konu", "KullaniciId", "OlusturmaTarihi" },
                values: new object[] { 1, true, new DateTime(2022, 2, 16, 20, 0, 35, 901, DateTimeKind.Local).AddTicks(9696), "Ağaç ve çiçeklerin bakımı", "Çevre düzenleme", 1, new DateTime(2022, 2, 16, 20, 0, 35, 901, DateTimeKind.Local).AddTicks(9688) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_KullaniciId",
                table: "AspNetUsers",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Daireler_Blokid",
                table: "Daireler",
                column: "Blokid");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciAidatlar_AidatId",
                table: "KullaniciAidatlar",
                column: "AidatId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciAidatlar_KullaniciId_AidatId",
                table: "KullaniciAidatlar",
                columns: new[] { "KullaniciId", "AidatId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciFaturalar_FaturaId",
                table: "KullaniciFaturalar",
                column: "FaturaId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciFaturalar_KullaniciId_FaturaId",
                table: "KullaniciFaturalar",
                columns: new[] { "KullaniciId", "FaturaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_DaireId",
                table: "Kullanicilar",
                column: "DaireId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_TCNo",
                table: "Kullanicilar",
                column: "TCNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mesajlar_KullaniciId",
                table: "Mesajlar",
                column: "KullaniciId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "KullaniciAidatlar");

            migrationBuilder.DropTable(
                name: "KullaniciFaturalar");

            migrationBuilder.DropTable(
                name: "Mesajlar");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Aidatlar");

            migrationBuilder.DropTable(
                name: "Faturalar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Daireler");

            migrationBuilder.DropTable(
                name: "Bloklar");
        }
    }
}
