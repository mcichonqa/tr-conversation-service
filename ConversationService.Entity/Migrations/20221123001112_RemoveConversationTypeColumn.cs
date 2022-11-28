using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversationService.Entity.Migrations
{
    /// <inheritdoc />
    public partial class RemoveConversationTypeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversationType",
                table: "ConversationDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndMeetingDate",
                table: "ConversationDetails",
                type: "datetime2",
                maxLength: 20,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndMeetingDate",
                table: "ConversationDetails");

            migrationBuilder.AddColumn<string>(
                name: "ConversationType",
                table: "ConversationDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
