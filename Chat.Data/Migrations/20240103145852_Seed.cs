using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_Users_ReceiverId",
                table: "DirectMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_Users_SenderId",
                table: "DirectMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_Groups_GroupId",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_Users_SenderId",
                table: "GroupMessages");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "General", null },
                    { 2, "Dev", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "IsAdmin", "Password" },
                values: new object[,]
                {
                    { 1, "luka@gmail.com", false, "luka" },
                    { 2, "mate@gmail.com", false, "mate" },
                    { 3, "sime@gmail.com", true, "sime" }
                });

            migrationBuilder.InsertData(
                table: "DirectMessages",
                columns: new[] { "DirectMessageId", "ReceiverId", "SenderId", "Text", "Timestamp" },
                values: new object[,]
                {
                    { 1, 2, 1, "Bok", new DateTime(2023, 1, 1, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, 1, 2, "Bok, Luka", new DateTime(2023, 1, 1, 18, 5, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "GroupMessages",
                columns: new[] { "GroupMessageId", "GroupId", "SenderId", "Text", "Timestamp" },
                values: new object[,]
                {
                    { 1, 1, 1, "Prva poruka u grupi", new DateTime(2023, 1, 1, 20, 1, 1, 0, DateTimeKind.Utc) },
                    { 2, 1, 2, "Bok, Luka", new DateTime(2023, 1, 1, 20, 1, 2, 0, DateTimeKind.Utc) },
                    { 3, 2, 1, "Ovo je dev kanal", new DateTime(2023, 1, 1, 21, 1, 2, 0, DateTimeKind.Utc) },
                    { 4, 2, 2, "Pozdrav", new DateTime(2023, 1, 1, 21, 2, 2, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "GroupUsers",
                columns: new[] { "GroupId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_Users_ReceiverId",
                table: "DirectMessages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_Users_SenderId",
                table: "DirectMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_Groups_GroupId",
                table: "GroupMessages",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_Users_SenderId",
                table: "GroupMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_Users_ReceiverId",
                table: "DirectMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_Users_SenderId",
                table: "DirectMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_Groups_GroupId",
                table: "GroupMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupMessages_Users_SenderId",
                table: "GroupMessages");

            migrationBuilder.DeleteData(
                table: "DirectMessages",
                keyColumn: "DirectMessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DirectMessages",
                keyColumn: "DirectMessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GroupMessages",
                keyColumn: "GroupMessageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GroupUsers",
                keyColumns: new[] { "GroupId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_Users_ReceiverId",
                table: "DirectMessages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_Users_SenderId",
                table: "DirectMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_Groups_GroupId",
                table: "GroupMessages",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupMessages_Users_SenderId",
                table: "GroupMessages",
                column: "SenderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
