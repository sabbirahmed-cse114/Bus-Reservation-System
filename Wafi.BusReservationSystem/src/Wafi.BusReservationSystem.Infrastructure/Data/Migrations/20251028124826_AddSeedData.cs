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
                    Name = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    TotalSeats = table.Column<int>(type: "integer", nullable: false),
                    BusType = table.Column<int>(type: "integer", nullable: false)
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
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BoardingPointId = table.Column<Guid>(type: "uuid", nullable: true),
                    DroppingPointId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusSchedules_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RouteDroppingPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteId = table.Column<Guid>(type: "uuid", nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: true),
                    DroppingPointsOrder = table.Column<int>(type: "integer", nullable: false),
                    ArrivalTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    DepartureTime = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteDroppingPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteDroppingPoints_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteDroppingPoints_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatNumber = table.Column<string>(type: "text", nullable: false),
                    Row = table.Column<int>(type: "integer", nullable: false),
                    Column = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_BusSchedules_BusScheduleId",
                        column: x => x.BusScheduleId,
                        principalTable: "BusSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BusScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PassengerId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeatId = table.Column<Guid>(type: "uuid", nullable: false),
                    BoardingPointId = table.Column<Guid>(type: "uuid", nullable: false),
                    DroppingPointId = table.Column<Guid>(type: "uuid", nullable: false),
                    BookingTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Fare = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_BusSchedules_BusScheduleId",
                        column: x => x.BusScheduleId,
                        principalTable: "BusSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_RouteDroppingPoints_BoardingPointId",
                        column: x => x.BoardingPointId,
                        principalTable: "RouteDroppingPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_RouteDroppingPoints_DroppingPointId",
                        column: x => x.DroppingPointId,
                        principalTable: "RouteDroppingPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "BusType", "CompanyName", "Name", "TotalSeats" },
                values: new object[,]
                {
                    { new Guid("a2b7e02c-0382-4f4f-9f88-eb2a6e0c27f8"), 1, "Green Line Paribahan", "Green Line Express", 40 },
                    { new Guid("aee2a129-1088-405d-9e02-7b78bae81ba1"), 0, "Hanif Paribahan", "Hanif Enterprise", 36 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("39b76299-f549-4fc6-99a0-a15a607cb510"), "Sirajgonj" },
                    { new Guid("4db86802-9aea-4e7e-801a-b05a2463be39"), "Khulna" },
                    { new Guid("c85c3f39-ab09-43b1-9b5c-32d7e420f9a1"), "Rajshahi" },
                    { new Guid("f91d9f76-694c-42d5-afca-69252dc86eff"), "Dhaka" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "MobileNumber", "Name" },
                values: new object[,]
                {
                    { new Guid("b1aa236b-9611-4e2c-8157-64a4be53c3ad"), "01776913524", "Sabbir Ahmed" },
                    { new Guid("d31771d2-0c5e-4e1f-92f0-4d68c6e3123f"), "01976913524", "Hasan Tarik" }
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "BoardingPointId", "DroppingPointId", "Name" },
                values: new object[,]
                {
                    { new Guid("b3c689f4-4c78-4a7c-9023-3b91a15519a0"), new Guid("f91d9f76-694c-42d5-afca-69252dc86eff"), new Guid("c85c3f39-ab09-43b1-9b5c-32d7e420f9a1"), "Dhaka to Rajshahi" },
                    { new Guid("d0be67e9-292e-4b0c-8c0d-1bb0a1e2e1a1"), new Guid("c85c3f39-ab09-43b1-9b5c-32d7e420f9a1"), new Guid("f91d9f76-694c-42d5-afca-69252dc86eff"), "Rajshahi to Dhaka" }
                });

            migrationBuilder.InsertData(
                table: "BusSchedules",
                columns: new[] { "Id", "ArrivalTime", "BusId", "DepartureTime", "JourneyDate", "Price", "RouteId" },
                values: new object[,]
                {
                    { new Guid("8a21b9e8-baee-4a3e-ae0b-9ab1c812f268"), new TimeSpan(0, 13, 30, 0, 0), new Guid("aee2a129-1088-405d-9e02-7b78bae81ba1"), new TimeSpan(0, 8, 0, 0, 0), new DateTime(2025, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 700, new Guid("d0be67e9-292e-4b0c-8c0d-1bb0a1e2e1a1") },
                    { new Guid("e5b270af-9491-4b8d-953e-126aa36820b7"), new TimeSpan(0, 12, 0, 0, 0), new Guid("a2b7e02c-0382-4f4f-9f88-eb2a6e0c27f8"), new TimeSpan(0, 7, 0, 0, 0), new DateTime(2025, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 800, new Guid("b3c689f4-4c78-4a7c-9023-3b91a15519a0") }
                });

            migrationBuilder.InsertData(
                table: "RouteDroppingPoints",
                columns: new[] { "Id", "ArrivalTime", "CityId", "DepartureTime", "DroppingPointsOrder", "RouteId" },
                values: new object[,]
                {
                    { new Guid("bf14e6d2-ba55-4fbb-ac59-48a5f8a6407a"), new TimeSpan(0, 9, 30, 0, 0), new Guid("39b76299-f549-4fc6-99a0-a15a607cb510"), new TimeSpan(0, 9, 45, 0, 0), 2, new Guid("b3c689f4-4c78-4a7c-9023-3b91a15519a0") },
                    { new Guid("c318afac-ee1a-43ba-97f1-79acbd78d2a5"), new TimeSpan(0, 12, 0, 0, 0), new Guid("c85c3f39-ab09-43b1-9b5c-32d7e420f9a1"), new TimeSpan(0, 12, 15, 0, 0), 3, new Guid("b3c689f4-4c78-4a7c-9023-3b91a15519a0") },
                    { new Guid("eab6b539-1981-460d-a0e1-7ee4a53b1299"), new TimeSpan(0, 7, 0, 0, 0), new Guid("f91d9f76-694c-42d5-afca-69252dc86eff"), new TimeSpan(0, 7, 15, 0, 0), 1, new Guid("b3c689f4-4c78-4a7c-9023-3b91a15519a0") }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "BusScheduleId", "Column", "Row", "SeatNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("9b8b9a8c-8234-4a1e-9e5e-ba0f41a36c8f"), new Guid("e5b270af-9491-4b8d-953e-126aa36820b7"), 2, 1, "A2", 1 },
                    { new Guid("b6d30d3e-8c67-4b83-86d5-1f47f0a22d2b"), new Guid("e5b270af-9491-4b8d-953e-126aa36820b7"), 1, 1, "A1", 0 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "BoardingPointId", "BookingTime", "BusScheduleId", "DroppingPointId", "Fare", "PassengerId", "SeatId", "Status" },
                values: new object[,]
                {
                    { new Guid("59f72a9f-0561-4b9f-8e7b-965f899b9e90"), new Guid("bf14e6d2-ba55-4fbb-ac59-48a5f8a6407a"), new DateTime(2025, 10, 26, 15, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e5b270af-9491-4b8d-953e-126aa36820b7"), new Guid("c318afac-ee1a-43ba-97f1-79acbd78d2a5"), 300m, new Guid("d31771d2-0c5e-4e1f-92f0-4d68c6e3123f"), new Guid("b6d30d3e-8c67-4b83-86d5-1f47f0a22d2b"), 0 },
                    { new Guid("aaef5d47-7c32-48aa-9c0d-0acb03b6e2d9"), new Guid("eab6b539-1981-460d-a0e1-7ee4a53b1299"), new DateTime(2025, 10, 25, 14, 30, 0, 0, DateTimeKind.Unspecified), new Guid("e5b270af-9491-4b8d-953e-126aa36820b7"), new Guid("bf14e6d2-ba55-4fbb-ac59-48a5f8a6407a"), 500m, new Guid("b1aa236b-9611-4e2c-8157-64a4be53c3ad"), new Guid("9b8b9a8c-8234-4a1e-9e5e-ba0f41a36c8f"), 1 }
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
                name: "IX_RouteDroppingPoints_CityId",
                table: "RouteDroppingPoints",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDroppingPoints_RouteId",
                table: "RouteDroppingPoints",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BusScheduleId",
                table: "Seats",
                column: "BusScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BoardingPointId",
                table: "Tickets",
                column: "BoardingPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BusScheduleId",
                table: "Tickets",
                column: "BusScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DroppingPointId",
                table: "Tickets",
                column: "DroppingPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PassengerId",
                table: "Tickets",
                column: "PassengerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "RouteDroppingPoints");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "BusSchedules");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
