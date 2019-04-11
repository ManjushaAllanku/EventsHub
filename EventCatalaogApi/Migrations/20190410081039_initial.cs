using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalaogApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "event_catalog_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_category_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "event_place_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Category = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Place = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventCatalog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    Datetime = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EventCategoryId = table.Column<int>(nullable: false),
                    EventPlaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCatalog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCatalog_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCatalog_EventPlaces_EventPlaceId",
                        column: x => x.EventPlaceId,
                        principalTable: "EventPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventCatalog_EventCategoryId",
                table: "EventCatalog",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCatalog_EventPlaceId",
                table: "EventCatalog",
                column: "EventPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventCatalog");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "EventPlaces");

            migrationBuilder.DropSequence(
                name: "event_catalog_hilo");

            migrationBuilder.DropSequence(
                name: "event_category_hilo");

            migrationBuilder.DropSequence(
                name: "event_place_hilo");
        }
    }
}
