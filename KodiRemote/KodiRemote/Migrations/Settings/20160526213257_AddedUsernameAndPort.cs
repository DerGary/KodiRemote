using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace KodiRemote.Migrations.Settings
{
    public partial class AddedUsernameAndPort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Kodis",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Kodis",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "WebsocketPort",
                table: "Kodis",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Password", table: "Kodis");
            migrationBuilder.DropColumn(name: "Username", table: "Kodis");
            migrationBuilder.DropColumn(name: "WebsocketPort", table: "Kodis");
        }
    }
}
