using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScreenProject.Migrations
{
    public partial class firstTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    BackgroungImg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    TemplateId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Occurence = table.Column<string>(nullable: true),
                    Priorty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplatesFields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PropertyName = table.Column<string>(nullable: true),
                    FontSize = table.Column<int>(nullable: false),
                    TopMargin = table.Column<int>(nullable: false),
                    LeftMargin = table.Column<int>(nullable: false),
                    FontFamily = table.Column<string>(nullable: true),
                    ForeColor = table.Column<string>(nullable: true),
                    TemplateId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplatesFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplatesFields_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventProps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    value = table.Column<string>(nullable: true),
                    TempfieldId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventProps_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventProps_TemplatesFields_TempfieldId",
                        column: x => x.TempfieldId,
                        principalTable: "TemplatesFields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventProps_EventId",
                table: "EventProps",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventProps_TempfieldId",
                table: "EventProps",
                column: "TempfieldId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_TemplateId",
                table: "Events",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplatesFields_TemplateId",
                table: "TemplatesFields",
                column: "TemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventProps");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "TemplatesFields");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
