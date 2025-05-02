using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PlayNirvanaTechExam.Migrations
{
    /// <inheritdoc />
    public partial class LocationsAndPlacesRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    StartedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Radius = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                schema: "identity",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    PrimaryType = table.Column<string>(type: "text", nullable: false),
                    PrimaryTypeDisplayName = table.Column<string>(type: "text", nullable: false),
                    NationalPhoneNumber = table.Column<string>(type: "text", nullable: false),
                    InternationalPhoneNumber = table.Column<string>(type: "text", nullable: false),
                    FormattedAddress = table.Column<string>(type: "text", nullable: false),
                    ShortFormattedAddress = table.Column<string>(type: "text", nullable: false),
                    Revision = table.Column<int>(type: "integer", nullable: false),
                    RegionCode = table.Column<string>(type: "text", nullable: false),
                    LanguageCode = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    SortingCode = table.Column<string>(type: "text", nullable: false),
                    AdministrativeArea = table.Column<string>(type: "text", nullable: false),
                    Locality = table.Column<string>(type: "text", nullable: false),
                    Sublocality = table.Column<string>(type: "text", nullable: false),
                    GlobalCode = table.Column<string>(type: "text", nullable: false),
                    CompoundCode = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    Rating = table.Column<double>(type: "double precision", nullable: true),
                    GoogleMapsUri = table.Column<string>(type: "text", nullable: false),
                    WebsiteUri = table.Column<string>(type: "text", nullable: false),
                    AdrFormatAddress = table.Column<string>(type: "text", nullable: false),
                    BusinessStatus = table.Column<int>(type: "integer", nullable: true),
                    PriceLevel = table.Column<int>(type: "integer", nullable: true),
                    IconMaskBaseUri = table.Column<string>(type: "text", nullable: false),
                    IconBackgroundColor = table.Column<string>(type: "text", nullable: false),
                    UtcOffsetMinutes = table.Column<int>(type: "integer", nullable: true),
                    UserRatingCount = table.Column<int>(type: "integer", nullable: true),
                    Takeout = table.Column<bool>(type: "boolean", nullable: true),
                    Delivery = table.Column<bool>(type: "boolean", nullable: true),
                    DineIn = table.Column<bool>(type: "boolean", nullable: true),
                    CurbsidePickup = table.Column<bool>(type: "boolean", nullable: true),
                    Reservable = table.Column<bool>(type: "boolean", nullable: true),
                    ServesBreakfast = table.Column<bool>(type: "boolean", nullable: true),
                    ServesLunch = table.Column<bool>(type: "boolean", nullable: true),
                    ServesDinner = table.Column<bool>(type: "boolean", nullable: true),
                    ServesBeer = table.Column<bool>(type: "boolean", nullable: true),
                    ServesWine = table.Column<bool>(type: "boolean", nullable: true),
                    ServesBrunch = table.Column<bool>(type: "boolean", nullable: true),
                    ServesVegetarianFood = table.Column<bool>(type: "boolean", nullable: true),
                    OutdoorSeating = table.Column<bool>(type: "boolean", nullable: true),
                    LiveMusic = table.Column<bool>(type: "boolean", nullable: true),
                    MenuForChildren = table.Column<bool>(type: "boolean", nullable: true),
                    ServesCocktails = table.Column<bool>(type: "boolean", nullable: true),
                    ServesDessert = table.Column<bool>(type: "boolean", nullable: true),
                    ServesCoffee = table.Column<bool>(type: "boolean", nullable: true),
                    GoodForChildren = table.Column<bool>(type: "boolean", nullable: true),
                    AllowsDogs = table.Column<bool>(type: "boolean", nullable: true),
                    Restroom = table.Column<bool>(type: "boolean", nullable: true),
                    GoodForGroups = table.Column<bool>(type: "boolean", nullable: true),
                    GoodForWatchingSports = table.Column<bool>(type: "boolean", nullable: true),
                    PureServiceAreaBusiness = table.Column<bool>(type: "boolean", nullable: true),
                    LocationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Places_Locations_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "identity",
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Places_LocationId",
                schema: "identity",
                table: "Places",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Places",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Locations",
                schema: "identity");
        }
    }
}
