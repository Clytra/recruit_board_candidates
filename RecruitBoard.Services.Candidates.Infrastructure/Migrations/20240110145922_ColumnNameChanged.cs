using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitBoard.Services.Candidates.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColumnNameChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "experiences");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "experiences");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "experiences");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "experiences");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "experiences");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "educations");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "educations");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "educations");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "educations");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "educations");

            migrationBuilder.RenameColumn(
                name: "Deleted",
                table: "candidates",
                newName: "deleted");

            migrationBuilder.RenameColumn(
                name: "LastModifiedDate",
                table: "candidates",
                newName: "last_modified_date");

            migrationBuilder.RenameColumn(
                name: "LastModifiedBy",
                table: "candidates",
                newName: "last_modified_by");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "candidates",
                newName: "created_date");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "candidates",
                newName: "created_by");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "deleted",
                table: "candidates",
                newName: "Deleted");

            migrationBuilder.RenameColumn(
                name: "last_modified_date",
                table: "candidates",
                newName: "LastModifiedDate");

            migrationBuilder.RenameColumn(
                name: "last_modified_by",
                table: "candidates",
                newName: "LastModifiedBy");

            migrationBuilder.RenameColumn(
                name: "created_date",
                table: "candidates",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "candidates",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "experiences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "experiences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "experiences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "experiences",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "educations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "educations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "educations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "educations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "educations",
                type: "datetime2",
                nullable: true);
        }
    }
}
