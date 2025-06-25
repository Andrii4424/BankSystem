using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class TransiteToGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Cards_Banks_BankId", table: "Cards");
            migrationBuilder.DropForeignKey(name: "FK_Persons_Banks_BankId", table: "Persons");

            migrationBuilder.DropPrimaryKey(name: "PK_Persons", table: "Persons");
            migrationBuilder.DropPrimaryKey(name: "PK_Cards", table: "Cards");
            migrationBuilder.DropPrimaryKey(name: "PK_Banks", table: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Persons_BankId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Cards_BankId",
                table: "Cards");

            migrationBuilder.DropColumn(name: "Id", table: "Persons");
            migrationBuilder.DropColumn(name: "BankId", table: "Persons");

            migrationBuilder.DropColumn(name: "Id", table: "Cards");
            migrationBuilder.DropColumn(name: "BankId", table: "Cards");

            migrationBuilder.DropColumn(name: "Id", table: "Banks");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Banks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AddColumn<Guid>(
                name: "BankId",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AddColumn<Guid>(
                name: "BankId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.AddPrimaryKey(name: "PK_Banks", table: "Banks", column: "Id");
            migrationBuilder.AddPrimaryKey(name: "PK_Cards", table: "Cards", column: "Id");
            migrationBuilder.AddPrimaryKey(name: "PK_Persons", table: "Persons", column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Banks_BankId",
                table: "Cards",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Banks_BankId",
                table: "Persons",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Удаляем FK
            migrationBuilder.DropForeignKey(name: "FK_Cards_Banks_BankId", table: "Cards");
            migrationBuilder.DropForeignKey(name: "FK_Persons_Banks_BankId", table: "Persons");

            migrationBuilder.DropPrimaryKey(name: "PK_Persons", table: "Persons");
            migrationBuilder.DropPrimaryKey(name: "PK_Cards", table: "Cards");
            migrationBuilder.DropPrimaryKey(name: "PK_Banks", table: "Banks");

            migrationBuilder.DropColumn(name: "Id", table: "Persons");
            migrationBuilder.DropColumn(name: "BankId", table: "Persons");

            migrationBuilder.DropColumn(name: "Id", table: "Cards");
            migrationBuilder.DropColumn(name: "BankId", table: "Cards");

            migrationBuilder.DropColumn(name: "Id", table: "Banks");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Banks",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BankId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(name: "PK_Banks", table: "Banks", column: "Id");
            migrationBuilder.AddPrimaryKey(name: "PK_Cards", table: "Cards", column: "Id");
            migrationBuilder.AddPrimaryKey(name: "PK_Persons", table: "Persons", column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Banks_BankId",
                table: "Cards",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Banks_BankId",
                table: "Persons",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
