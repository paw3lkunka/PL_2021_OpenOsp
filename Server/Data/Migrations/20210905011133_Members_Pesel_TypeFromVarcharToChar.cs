using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenOsp.Server.Data.Migrations
{
    public partial class Members_Pesel_TypeFromVarcharToChar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Members",
                type: "char(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Members",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(11)",
                oldMaxLength: 11);
        }
    }
}
