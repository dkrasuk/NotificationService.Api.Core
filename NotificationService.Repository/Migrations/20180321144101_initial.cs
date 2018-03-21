using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NotificationService.Repository.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Notification");

            migrationBuilder.CreateTable(
                name: "notifications",
                schema: "Notification",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    body = table.Column<string>(nullable: true),
                    chanel = table.Column<string>(nullable: true),
                    created_date = table.Column<DateTime>(nullable: false),
                    isreaded = table.Column<bool>(nullable: false),
                    modify_date = table.Column<DateTime>(nullable: true),
                    protocol = table.Column<int>(nullable: false),
                    receiver = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notifications_id",
                schema: "Notification",
                table: "notifications",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notifications",
                schema: "Notification");
        }
    }
}
