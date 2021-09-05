using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenOsp.Server.Data.Migrations
{
    public partial class ValidationAndOptimalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_AspNetUsers_UserId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AspNetUsers_UserId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_AspNetUsers_UserId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Equipment");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Members",
                newName: "owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_Members_UserId",
                table: "Members",
                newName: "IX_Members_owner_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Equipment",
                newName: "owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_UserId",
                table: "Equipment",
                newName: "IX_Equipment_owner_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Actions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Actions",
                newName: "owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_UserId",
                table: "Actions",
                newName: "IX_Actions_owner_id");

            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Members",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Members",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RegistryNumber",
                table: "Equipment",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(15)",
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Equipment",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Equipment",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(85)",
                maxLength: 85,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(85)",
                oldMaxLength: 85,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Actions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_AspNetUsers_owner_id",
                table: "Actions",
                column: "owner_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AspNetUsers_owner_id",
                table: "Equipment",
                column: "owner_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AspNetUsers_owner_id",
                table: "Members",
                column: "owner_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_AspNetUsers_owner_id",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AspNetUsers_owner_id",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_AspNetUsers_owner_id",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "Members",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_owner_id",
                table: "Members",
                newName: "IX_Members_UserId");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "Equipment",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_owner_id",
                table: "Equipment",
                newName: "IX_Equipment_UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Actions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "Actions",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_owner_id",
                table: "Actions",
                newName: "IX_Actions_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Pesel",
                table: "Members",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Members",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "RegistryNumber",
                table: "Equipment",
                type: "character varying(15)",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Equipment",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Equipment",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Equipment",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(85)",
                maxLength: 85,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(85)",
                oldMaxLength: 85);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Actions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_AspNetUsers_UserId",
                table: "Actions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AspNetUsers_UserId",
                table: "Equipment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AspNetUsers_UserId",
                table: "Members",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
