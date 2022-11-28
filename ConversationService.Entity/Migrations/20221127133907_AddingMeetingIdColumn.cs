using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConversationService.Entity.Migrations
{
    /// <inheritdoc />
    public partial class AddingMeetingIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MeetingId",
                table: "ConversationDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "ConversationDetails");
        }
    }
}
