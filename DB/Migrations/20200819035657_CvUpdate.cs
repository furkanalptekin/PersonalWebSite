using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class CvUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "B64",
                table: "CV");

            migrationBuilder.AlterColumn<string>(
                name: "Meslek",
                table: "Kisi",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DogumTarihi",
                table: "Kisi",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "CV",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EklemeTarihi",
                table: "Basarilar",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "Aktif",
                table: "Basarilar",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "1");

            migrationBuilder.CreateTable(
                name: "SiteBilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogAktif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteBilgileri", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteBilgileri");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "CV");

            migrationBuilder.AlterColumn<string>(
                name: "Meslek",
                table: "Kisi",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DogumTarihi",
                table: "Kisi",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<string>(
                name: "B64",
                table: "CV",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EklemeTarihi",
                table: "Basarilar",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<bool>(
                name: "Aktif",
                table: "Basarilar",
                type: "bit",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool));
        }
    }
}
