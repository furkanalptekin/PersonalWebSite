using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class BasariDefaultDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NameSurname = table.Column<string>(maxLength: 256, nullable: true),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    NameSurname = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    EklemeTarihi = table.Column<DateTime>(nullable: false),
                    DegisimTarihi = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Basarilar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(maxLength: 255, nullable: false),
                    Firma = table.Column<string>(maxLength: 255, nullable: false),
                    Tarih = table.Column<string>(maxLength: 255, nullable: true),
                    Aciklama = table.Column<string>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false, defaultValueSql: "1"),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basarilar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Baslik = table.Column<string>(maxLength: 120, nullable: false),
                    Ozet = table.Column<string>(maxLength: 400, nullable: false),
                    Detay = table.Column<string>(nullable: false),
                    GosterimBaslangicTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    GosterimBitisTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Fotograf = table.Column<string>(nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CV",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CvAdi = table.Column<string>(maxLength: 255, nullable: false),
                    B64 = table.Column<string>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CV", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobiler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(maxLength: 255, nullable: false),
                    Ikon = table.Column<string>(nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirId = table.Column<int>(nullable: true),
                    IlceAdi = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeslekiDeneyim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firma = table.Column<string>(maxLength: 255, nullable: false),
                    BaslangicTarih = table.Column<DateTime>(type: "datetime", nullable: true),
                    BitisTarih = table.Column<DateTime>(type: "datetime", nullable: true),
                    Pozisyon = table.Column<string>(maxLength: 255, nullable: false),
                    Adres = table.Column<string>(nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    FirmaIcon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeslekiDeneyim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projeler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(maxLength: 255, nullable: false),
                    Link = table.Column<string>(nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    BitisTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    KullanilanDiller = table.Column<string>(maxLength: 255, nullable: false),
                    Aciklama = table.Column<string>(nullable: false),
                    YapilisNedeni = table.Column<string>(maxLength: 255, nullable: true),
                    Kategori = table.Column<string>(nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referanslar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(maxLength: 255, nullable: false),
                    Soyadi = table.Column<string>(maxLength: 255, nullable: false),
                    Telefon = table.Column<string>(maxLength: 255, nullable: true),
                    EPosta = table.Column<string>(maxLength: 255, nullable: false),
                    Meslek = table.Column<string>(maxLength: 255, nullable: true),
                    Firma = table.Column<string>(maxLength: 255, nullable: true),
                    Pozisyon = table.Column<string>(maxLength: 255, nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referanslar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sehir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehir", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sertifikalar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(maxLength: 255, nullable: false),
                    Brans = table.Column<string>(maxLength: 255, nullable: false),
                    Firma = table.Column<string>(maxLength: 255, nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime", nullable: true),
                    GecerlilikSuresi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sertifikalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SosyalMedya",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SosyalMedyaAdi = table.Column<string>(maxLength: 255, nullable: false),
                    Adres = table.Column<string>(maxLength: 255, nullable: false),
                    Ikon = table.Column<string>(nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SosyalMedya", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YabanciDil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(maxLength: 255, nullable: false),
                    Seviyesi = table.Column<string>(maxLength: 255, nullable: false),
                    OkumaSeviyesi = table.Column<string>(maxLength: 255, nullable: false),
                    YazmaSeviyesi = table.Column<string>(maxLength: 255, nullable: false),
                    KonusmaSeviyesi = table.Column<string>(maxLength: 255, nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YabanciDil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YetenekKategori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(maxLength: 255, nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YetenekKategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaim_AspNetRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AspNetUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaim_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogin_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRole_AspNetRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRole_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserToken_AspNetUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Egitim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OkulAdi = table.Column<string>(maxLength: 255, nullable: false),
                    EgitimSeviyesi = table.Column<string>(maxLength: 50, nullable: false),
                    MezuniyetDerecesi = table.Column<string>(maxLength: 50, nullable: true),
                    NotSistemi = table.Column<int>(nullable: true),
                    BaslangicTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    BitisTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Fakulte = table.Column<string>(maxLength: 255, nullable: true),
                    Bolum = table.Column<string>(maxLength: 255, nullable: true),
                    EgitimDili = table.Column<string>(maxLength: 255, nullable: true),
                    SehirId = table.Column<int>(nullable: true),
                    IlceId = table.Column<int>(nullable: true),
                    EkAciklama = table.Column<string>(nullable: true),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Aktif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitim", x => x.Id);
                    table.ForeignKey(
                        name: "Egitim_Ilce_FK",
                        column: x => x.IlceId,
                        principalTable: "Ilce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Egitim_Sehir_FK",
                        column: x => x.SehirId,
                        principalTable: "Sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(maxLength: 255, nullable: false),
                    Soyadi = table.Column<string>(maxLength: 255, nullable: false),
                    EPosta = table.Column<string>(maxLength: 255, nullable: false),
                    Telefon = table.Column<string>(maxLength: 255, nullable: true),
                    CepTelefonu = table.Column<string>(maxLength: 255, nullable: false),
                    SabitTelefonu = table.Column<string>(maxLength: 255, nullable: true),
                    Faks = table.Column<string>(maxLength: 255, nullable: true),
                    SigaraKullanımDurumu = table.Column<bool>(nullable: true),
                    AlkolKullanımDurumu = table.Column<bool>(nullable: true),
                    EngelDurumu = table.Column<bool>(nullable: true),
                    SeyahatEngeliDurumu = table.Column<bool>(nullable: true),
                    Ehliyet = table.Column<string>(maxLength: 255, nullable: true),
                    KanGrubu = table.Column<string>(maxLength: 255, nullable: true),
                    MedeniDurum = table.Column<string>(maxLength: 255, nullable: true),
                    Cinsiyet = table.Column<string>(maxLength: 255, nullable: true),
                    Fotograf = table.Column<string>(nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    AskerlikDurumu = table.Column<string>(maxLength: 50, nullable: true),
                    TecilTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    Meslek = table.Column<string>(maxLength: 255, nullable: true),
                    DogumSehirId = table.Column<int>(nullable: true),
                    DogumIlceId = table.Column<int>(nullable: true),
                    KonumSehirId = table.Column<int>(nullable: true),
                    KonumIlceId = table.Column<int>(nullable: true),
                    Uyruk = table.Column<string>(maxLength: 255, nullable: true),
                    IsAramaDurumu = table.Column<string>(maxLength: 255, nullable: true),
                    KariyerHedefi = table.Column<string>(nullable: true),
                    OnYazi = table.Column<string>(nullable: true),
                    UcretBeklentisi = table.Column<string>(maxLength: 255, nullable: true),
                    CalismakIstenilenSehir = table.Column<string>(maxLength: 255, nullable: true),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisi", x => x.Id);
                    table.ForeignKey(
                        name: "Kisi_DogumIlce_Id",
                        column: x => x.DogumIlceId,
                        principalTable: "Ilce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Kisi_DogumSehir_Id",
                        column: x => x.DogumSehirId,
                        principalTable: "Sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Kisi_KonumIlce_Id",
                        column: x => x.KonumIlceId,
                        principalTable: "Ilce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Kisi_KonumSehir_Id",
                        column: x => x.KonumSehirId,
                        principalTable: "Sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Yetenekler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(maxLength: 100, nullable: false),
                    BasariOrani = table.Column<int>(nullable: false),
                    RenkKodu = table.Column<string>(maxLength: 7, nullable: true),
                    KategoriId = table.Column<int>(nullable: false),
                    Aktif = table.Column<bool>(nullable: false),
                    EklemeTarihi = table.Column<DateTime>(type: "datetime", nullable: false),
                    DegisimTarihi = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetenekler", x => x.Id);
                    table.ForeignKey(
                        name: "Yetenek_YetenekKategori_FK",
                        column: x => x.KategoriId,
                        principalTable: "YetenekKategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRole",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaim_RoleId",
                table: "AspNetRoleClaim",
                column: "RoleId");

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
                name: "EmailIndex",
                table: "AspNetUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUser",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaim_UserId",
                table: "AspNetUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogin_UserId",
                table: "AspNetUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRole_RoleId",
                table: "AspNetUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_IlceId",
                table: "Egitim",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Egitim_SehirId",
                table: "Egitim",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Kisi_DogumIlceId",
                table: "Kisi",
                column: "DogumIlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Kisi_DogumSehirId",
                table: "Kisi",
                column: "DogumSehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Kisi_KonumIlceId",
                table: "Kisi",
                column: "KonumIlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Kisi_KonumSehirId",
                table: "Kisi",
                column: "KonumSehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Yetenekler_KategoriId",
                table: "Yetenekler",
                column: "KategoriId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaim");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaim");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogin");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRole");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserToken");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Basarilar");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "CV");

            migrationBuilder.DropTable(
                name: "Egitim");

            migrationBuilder.DropTable(
                name: "Hobiler");

            migrationBuilder.DropTable(
                name: "Kisi");

            migrationBuilder.DropTable(
                name: "MeslekiDeneyim");

            migrationBuilder.DropTable(
                name: "Projeler");

            migrationBuilder.DropTable(
                name: "Referanslar");

            migrationBuilder.DropTable(
                name: "Sertifikalar");

            migrationBuilder.DropTable(
                name: "SosyalMedya");

            migrationBuilder.DropTable(
                name: "YabanciDil");

            migrationBuilder.DropTable(
                name: "Yetenekler");

            migrationBuilder.DropTable(
                name: "AspNetRole");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUser");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "Sehir");

            migrationBuilder.DropTable(
                name: "YetenekKategori");
        }
    }
}
