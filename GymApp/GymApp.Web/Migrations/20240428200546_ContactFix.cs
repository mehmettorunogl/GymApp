using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ContactFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentComment",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CommentEmail",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CommentName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CommentTitle",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "ContactMap",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ContactMap",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CommentComment",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommentEmail",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommentName",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommentTitle",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }
    }
}
