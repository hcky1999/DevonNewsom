using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoard.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "users",
                type: "VARCHAR(45)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "users",
                type: "VARCHAR(45)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "VARCHAR(45)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "users",
                nullable: false,
                oldClrType: typeof(string))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "users",
                type: "VARCHAR(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "users",
                type: "VARCHAR(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "VARCHAR(45)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(45)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "users",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
