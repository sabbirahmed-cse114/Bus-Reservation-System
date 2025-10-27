using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wafi.BusReservationSystem.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add1SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "RouteDroppingPoints");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "RouteDroppingPoints");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Routes",
                newName: "TotalStops");

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("39b76299-f549-4fc6-99a0-a15a607cb510"),
                column: "TotalStops",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("81630e00-df5d-4c49-a335-aaeb0e44a4d4"),
                column: "TotalStops",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalStops",
                table: "Routes",
                newName: "Order");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DepartureTime",
                table: "Routes",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ArrivalTime",
                table: "RouteDroppingPoints",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "DepartureTime",
                table: "RouteDroppingPoints",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "RouteDroppingPoints",
                keyColumn: "Id",
                keyValue: new Guid("164dc434-d1c9-4220-88f0-407517f7434c"),
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 7, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteDroppingPoints",
                keyColumn: "Id",
                keyValue: new Guid("4db86802-9aea-4e7e-801a-b05a2463be39"),
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 20, 0, 0, 0), new TimeSpan(0, 21, 0, 0, 0) });

            migrationBuilder.UpdateData(
                table: "RouteDroppingPoints",
                keyColumn: "Id",
                keyValue: new Guid("a83f3b24-cb63-4ec4-bc80-ef4eaaba047d"),
                columns: new[] { "ArrivalTime", "DepartureTime" },
                values: new object[] { new TimeSpan(0, 10, 0, 0, 0), new TimeSpan(0, 10, 5, 0, 0) });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("39b76299-f549-4fc6-99a0-a15a607cb510"),
                columns: new[] { "DepartureTime", "Order" },
                values: new object[] { new TimeSpan(0, 18, 0, 0, 0), 1 });

            migrationBuilder.UpdateData(
                table: "Routes",
                keyColumn: "Id",
                keyValue: new Guid("81630e00-df5d-4c49-a335-aaeb0e44a4d4"),
                columns: new[] { "DepartureTime", "Order" },
                values: new object[] { new TimeSpan(0, 21, 0, 0, 0), 1 });
        }
    }
}
