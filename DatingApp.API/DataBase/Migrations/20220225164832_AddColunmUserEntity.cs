﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatingApp.API.Database.Migrations
{
    public partial class AddColunmUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "User",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "User",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "User",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "User",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnowAs",
                table: "User",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "User",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "User");

            migrationBuilder.DropColumn(
                name: "City",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "User");

            migrationBuilder.DropColumn(
                name: "KnowAs",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "User");
        }
    }
}
