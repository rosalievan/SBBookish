using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookish2.Migrations
{
    public partial class RemoveNonNullableConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Members_MemberId",
                table: "Copies");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Copies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Members_MemberId",
                table: "Copies",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Copies_Members_MemberId",
                table: "Copies");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Copies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Copies_Members_MemberId",
                table: "Copies",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
