using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventRenameAddingPriorityPackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventEntityEventPackageEntity_EventEntities_EventsId",
                table: "EventEntityEventPackageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEntityEventPackageEntity_PackageEntities_PackagesId",
                table: "EventEntityEventPackageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageEntities",
                table: "PackageEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventEntities",
                table: "EventEntities");

            migrationBuilder.RenameTable(
                name: "PackageEntities",
                newName: "Package");

            migrationBuilder.RenameTable(
                name: "EventEntities",
                newName: "Event");

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Package",
                table: "Package",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventEntityEventPackageEntity_Event_EventsId",
                table: "EventEntityEventPackageEntity",
                column: "EventsId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEntityEventPackageEntity_Package_PackagesId",
                table: "EventEntityEventPackageEntity",
                column: "PackagesId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventEntityEventPackageEntity_Event_EventsId",
                table: "EventEntityEventPackageEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEntityEventPackageEntity_Package_PackagesId",
                table: "EventEntityEventPackageEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Package",
                table: "Package");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Package");

            migrationBuilder.RenameTable(
                name: "Package",
                newName: "PackageEntities");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "EventEntities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageEntities",
                table: "PackageEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventEntities",
                table: "EventEntities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventEntityEventPackageEntity_EventEntities_EventsId",
                table: "EventEntityEventPackageEntity",
                column: "EventsId",
                principalTable: "EventEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEntityEventPackageEntity_PackageEntities_PackagesId",
                table: "EventEntityEventPackageEntity",
                column: "PackagesId",
                principalTable: "PackageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
