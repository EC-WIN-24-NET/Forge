using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(36)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(
                        type: "money",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "EventPackage",
                columns: table => new
                {
                    Id = table
                        .Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Perks = table.Column<string>(
                        type: "nvarchar(max)",
                        maxLength: 500,
                        nullable: true
                    ),
                    Price = table.Column<decimal>(
                        type: "money",
                        precision: 18,
                        scale: 2,
                        nullable: false
                    ),
                    Currency = table.Column<string>(type: "nvarchar(3)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPackage", x => x.Id);
                }
            );

            migrationBuilder.CreateTable(
                name: "EventEntityEventPackageEntity",
                columns: table => new
                {
                    EventsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackagesId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "PK_EventEntityEventPackageEntity",
                        x => new { x.EventsId, x.PackagesId }
                    );
                    table.ForeignKey(
                        name: "FK_EventEntityEventPackageEntity_EventPackage_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "EventPackage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                    table.ForeignKey(
                        name: "FK_EventEntityEventPackageEntity_Event_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_EventEntityEventPackageEntity_PackagesId",
                table: "EventEntityEventPackageEntity",
                column: "PackagesId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "EventEntityEventPackageEntity");

            migrationBuilder.DropTable(name: "EventPackage");

            migrationBuilder.DropTable(name: "Event");
        }
    }
}
