using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NotificationService.Repository.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_notification_protocol_NotificationProtocolId",
                schema: "Notification",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_NotificationProtocolId",
                schema: "Notification",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "NotificationProtocolId",
                schema: "Notification",
                table: "notifications");

            migrationBuilder.AddColumn<int>(
                name: "ProtocolId",
                schema: "Notification",
                table: "notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_ProtocolId",
                schema: "Notification",
                table: "notifications",
                column: "ProtocolId");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_notification_protocol_ProtocolId",
                schema: "Notification",
                table: "notifications",
                column: "ProtocolId",
                principalSchema: "Notification",
                principalTable: "notification_protocol",
                principalColumn: "protocol_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_notification_protocol_ProtocolId",
                schema: "Notification",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_ProtocolId",
                schema: "Notification",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "ProtocolId",
                schema: "Notification",
                table: "notifications");

            migrationBuilder.AddColumn<int>(
                name: "NotificationProtocolId",
                schema: "Notification",
                table: "notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_NotificationProtocolId",
                schema: "Notification",
                table: "notifications",
                column: "NotificationProtocolId");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_notification_protocol_NotificationProtocolId",
                schema: "Notification",
                table: "notifications",
                column: "NotificationProtocolId",
                principalSchema: "Notification",
                principalTable: "notification_protocol",
                principalColumn: "protocol_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
