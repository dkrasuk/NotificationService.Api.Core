using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NotificationService.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Notification");

            migrationBuilder.CreateTable(
                name: "notification_protocol",
                schema: "Notification",
                columns: table => new
                {
                    uid_protocol = table.Column<Guid>(nullable: false),
                    protocol_id = table.Column<int>(nullable: false),
                    protocol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification_protocol", x => x.uid_protocol);
                });

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
                    Protocoluid_protocol = table.Column<Guid>(nullable: false),
                    receiver = table.Column<string>(nullable: true),
                    title = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_notifications_notification_protocol_Protocoluid_protocol",
                        column: x => x.Protocoluid_protocol,
                        principalSchema: "Notification",
                        principalTable: "notification_protocol",
                        principalColumn: "uid_protocol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notification_protocol_protocol_id",
                schema: "Notification",
                table: "notification_protocol",
                column: "protocol_id");

            migrationBuilder.CreateIndex(
                name: "IX_notification_protocol_uid_protocol",
                schema: "Notification",
                table: "notification_protocol",
                column: "uid_protocol");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_id",
                schema: "Notification",
                table: "notifications",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_Protocoluid_protocol",
                schema: "Notification",
                table: "notifications",
                column: "Protocoluid_protocol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notifications",
                schema: "Notification");

            migrationBuilder.DropTable(
                name: "notification_protocol",
                schema: "Notification");
        }
    }
}
