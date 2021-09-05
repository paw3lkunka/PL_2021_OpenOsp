using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenOsp.Server.Data.Migrations
{
    public partial class ColumnNamesToPascalCaseAndVarcharsResize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionEquipment_Actions_action_id",
                table: "ActionEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionEquipment_Equipment_equipment_id",
                table: "ActionEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionMembers_Actions_action_id",
                table: "ActionMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionMembers_Members_member_id",
                table: "ActionMembers");

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
                name: "id",
                table: "Members",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "Members",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_owner_id",
                table: "Members",
                newName: "IX_Members_OwnerId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Equipment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "Equipment",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_owner_id",
                table: "Equipment",
                newName: "IX_Equipment_OwnerId");

            migrationBuilder.RenameColumn(
                name: "owner_id",
                table: "Actions",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_owner_id",
                table: "Actions",
                newName: "IX_Actions_OwnerId");

            migrationBuilder.RenameColumn(
                name: "member_id",
                table: "ActionMembers",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "action_id",
                table: "ActionMembers",
                newName: "ActionId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionMembers_member_id",
                table: "ActionMembers",
                newName: "IX_ActionMembers_MemberId");

            migrationBuilder.RenameColumn(
                name: "equipment_id",
                table: "ActionEquipment",
                newName: "EquipmentId");

            migrationBuilder.RenameColumn(
                name: "action_id",
                table: "ActionEquipment",
                newName: "ActionId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionEquipment_equipment_id",
                table: "ActionEquipment",
                newName: "IX_ActionEquipment_EquipmentId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Members",
                type: "character varying(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "character varying(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "RegistryNumber",
                table: "Equipment",
                type: "varchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Equipment",
                type: "character varying(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Equipment",
                type: "character varying(24)",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(85)",
                oldMaxLength: 85,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "character varying(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(85)",
                oldMaxLength: 85,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                type: "character varying(16)",
                maxLength: 16,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(85)",
                oldMaxLength: 85,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(85)",
                oldMaxLength: 85);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(85)",
                oldMaxLength: 85,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Actions",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionEquipment_Actions_ActionId",
                table: "ActionEquipment",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionEquipment_Equipment_EquipmentId",
                table: "ActionEquipment",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionMembers_Actions_ActionId",
                table: "ActionMembers",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionMembers_Members_MemberId",
                table: "ActionMembers",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_AspNetUsers_OwnerId",
                table: "Actions",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AspNetUsers_OwnerId",
                table: "Equipment",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Members_AspNetUsers_OwnerId",
                table: "Members",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionEquipment_Actions_ActionId",
                table: "ActionEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionEquipment_Equipment_EquipmentId",
                table: "ActionEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionMembers_Actions_ActionId",
                table: "ActionMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionMembers_Members_MemberId",
                table: "ActionMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Actions_AspNetUsers_OwnerId",
                table: "Actions");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AspNetUsers_OwnerId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_AspNetUsers_OwnerId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Members",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Members",
                newName: "owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_Members_OwnerId",
                table: "Members",
                newName: "IX_Members_owner_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Equipment",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Equipment",
                newName: "owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_Equipment_OwnerId",
                table: "Equipment",
                newName: "IX_Equipment_owner_id");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Actions",
                newName: "owner_id");

            migrationBuilder.RenameIndex(
                name: "IX_Actions_OwnerId",
                table: "Actions",
                newName: "IX_Actions_owner_id");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "ActionMembers",
                newName: "member_id");

            migrationBuilder.RenameColumn(
                name: "ActionId",
                table: "ActionMembers",
                newName: "action_id");

            migrationBuilder.RenameIndex(
                name: "IX_ActionMembers_MemberId",
                table: "ActionMembers",
                newName: "IX_ActionMembers_member_id");

            migrationBuilder.RenameColumn(
                name: "EquipmentId",
                table: "ActionEquipment",
                newName: "equipment_id");

            migrationBuilder.RenameColumn(
                name: "ActionId",
                table: "ActionEquipment",
                newName: "action_id");

            migrationBuilder.RenameIndex(
                name: "IX_ActionEquipment_EquipmentId",
                table: "ActionEquipment",
                newName: "IX_ActionEquipment_equipment_id");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Members",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(24)",
                oldMaxLength: 24);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Members",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(24)",
                oldMaxLength: 24);

            migrationBuilder.AlterColumn<string>(
                name: "RegistryNumber",
                table: "Equipment",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Equipment",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(24)",
                oldMaxLength: 24);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Equipment",
                type: "character varying(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(24)",
                oldMaxLength: 24);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16);

            migrationBuilder.AlterColumn<string>(
                name: "SecurityStamp",
                table: "AspNetUsers",
                type: "character varying(85)",
                maxLength: 85,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "character varying(85)",
                maxLength: 85,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(16)",
                oldMaxLength: 16,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "character varying(85)",
                maxLength: 85,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "character varying(85)",
                maxLength: 85,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                type: "character varying(85)",
                maxLength: 85,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Actions",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionEquipment_Actions_action_id",
                table: "ActionEquipment",
                column: "action_id",
                principalTable: "Actions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionEquipment_Equipment_equipment_id",
                table: "ActionEquipment",
                column: "equipment_id",
                principalTable: "Equipment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionMembers_Actions_action_id",
                table: "ActionMembers",
                column: "action_id",
                principalTable: "Actions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionMembers_Members_member_id",
                table: "ActionMembers",
                column: "member_id",
                principalTable: "Members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
