using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class ContactChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "ContactDescription",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Contacts",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactFacebookRedirectUrl",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactImageUrl",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactInstagramRedirectUrl",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactLinkedinRedirectUrl",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactMap",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Contacts",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactTitle",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactXRedirectUrl",
                table: "Contacts",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ContactDescription",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactFacebookRedirectUrl",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactImageUrl",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactInstagramRedirectUrl",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactLinkedinRedirectUrl",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactMap",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactTitle",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactXRedirectUrl",
                table: "Contacts");
        }
    }
}
