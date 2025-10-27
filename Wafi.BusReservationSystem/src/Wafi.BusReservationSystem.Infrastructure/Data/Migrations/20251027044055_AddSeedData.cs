using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Wafi.BusReservationSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    BusName = table.Column<string>(type: "text", nullable: false),
                    TotalSeats = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MobileNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatNumber = table.Column<string>(type: "text", nullable: false),
                    Row = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BoardingPointId = table.Column<Guid>(type: "uuid", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Routes_Cities_BoardingPointId",
                        column: x => x.BoardingPointId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatNumber = table.Column<string>(type: "text", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusId = table.Column<Guid>(type: "uuid", nullable: false),
                    JourneyDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusSchedules_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusSchedules_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteDroppingPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: true),
                    DroppingPointId = table.Column<Guid>(type: "uuid", nullable: true),
                    DroppingPointCityId = table.Column<Guid>(type: "uuid", nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DepartureTime = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteDroppingPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteDroppingPoints_Cities_DroppingPointCityId",
                        column: x => x.DroppingPointCityId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RouteDroppingPoints_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "BusName", "CompanyName", "TotalSeats" },
                values: new object[,]
                {
                    { new Guid("0fadbf4c-f8cf-4937-86a2-0ca33feb33f9"), "Hanif Volvo AC", "Hanif Enterprise", 40 },
                    { new Guid("39b76299-f549-4fc6-99a0-a15a607cb510"), "Hino non-AC", "Hanif Enterprise", 34 },
                    { new Guid("81630e00-df5d-4c49-a335-aaeb0e44a4d4"), "Scania Business Class", "Green Line Paribahan", 40 },
                    { new Guid("cea979fd-08fd-4b38-b14a-b2518b481112"), "ENA Non AC", "ENA Enterprise", 36 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24a44820-cff8-4509-aa16-a1f4c5bb0bd5"), "Rajshahi" },
                    { new Guid("39b76299-f549-4fc6-99a0-a15a607cb510"), "Sirajgonj" },
                    { new Guid("4db86802-9aea-4e7e-801a-b05a2463be39"), "Khulna" },
                    { new Guid("f91d9f76-694c-42d5-afca-69252dc86eff"), "Dhaka" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "MobileNumber", "Name" },
                values: new object[,]
                {
                    { new Guid("39b76299-f549-4fc6-99a0-a15a607cb510"), "01976913524", "Sabbir Ahmed" },
                    { new Guid("81630e00-df5d-4c49-a335-aaeb0e44a4d4"), "01776913524", "Hasan Tarik" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "BoardingPointId", "DepartureTime", "Distance", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("39b76299-f549-4fc6-99a0-a15a607cb510"), new Guid("f91d9f76-694c-42d5-afca-69252dc86eff"), new TimeSpan(0, 18, 0, 0, 0), 250.0, null, 1 },
                    { new Guid("81630e00-df5d-4c49-a335-aaeb0e44a4d4"), new Guid("f91d9f76-694c-42d5-afca-69252dc86eff"), new TimeSpan(0, 21, 0, 0, 0), 650.0, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "BusSchedules",
                columns: new[] { "Id", "ArrivalTime", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    { new Guid("164dc434-d1c9-4220-88f0-407517f7434c"), new TimeSpan(0, 8, 0, 0, 0), new Guid("0fadbf4c-f8cf-4937-86a2-0ca33feb33f9"), new TimeSpan(0, 10, 0, 0, 0), new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 700, new Guid("39b76299-f549-4fc6-99a0-a15a607cb510") },
                    { new Guid("a83f3b24-cb63-4ec4-bc80-ef4eaaba047d"), new TimeSpan(0, 19, 0, 0, 0), new Guid("81630e00-df5d-4c49-a335-aaeb0e44a4d4"), new TimeSpan(0, 20, 0, 0, 0), new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200, new Guid("81630e00-df5d-4c49-a335-aaeb0e44a4d4") }
                });

            migrationBuilder.InsertData(
                table: "RouteDroppingPoints",
                columns: new[] { "Id", "ArrivalTime", "DepartureTime", "Distance", "DroppingPointCityId", "DroppingPointId", "Order", "RouteId" },
                values: new object[,]
                {
                    { new Guid("164dc434-d1c9-4220-88f0-407517f7434c"), new TimeSpan(0, 7, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0), 0.0, null, new Guid("f91d9f76-694c-42d5-afca-69252dc86eff"), 2, new Guid("39b76299-f549-4fc6-99a0-a15a607cb510") },
                    { new Guid("4db86802-9aea-4e7e-801a-b05a2463be39"), new TimeSpan(0, 20, 0, 0, 0), new TimeSpan(0, 21, 0, 0, 0), 50.0, null, new Guid("24a44820-cff8-4509-aa16-a1f4c5bb0bd5"), 4, new Guid("39b76299-f549-4fc6-99a0-a15a607cb510") },
                    { new Guid("a83f3b24-cb63-4ec4-bc80-ef4eaaba047d"), new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 10, 5, 0, 0), 25.0, null, new Guid("39b76299-f549-4fc6-99a0-a15a607cb510"), 3, new Guid("39b76299-f549-4fc6-99a0-a15a607cb510") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_BusId",
                table: "BusSchedules",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusSchedules_RouteId",
                table: "BusSchedules",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDroppingPoints_DroppingPointCityId",
                table: "RouteDroppingPoints",
                column: "DroppingPointCityId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDroppingPoints_RouteId",
                table: "RouteDroppingPoints",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_BoardingPointId",
                table: "Routes",
                column: "BoardingPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusSchedules");

            migrationBuilder.DropTable(
                name: "RouteDroppingPoints");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
