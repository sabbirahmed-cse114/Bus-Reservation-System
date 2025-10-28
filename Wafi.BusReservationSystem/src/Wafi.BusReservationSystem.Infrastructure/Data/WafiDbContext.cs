using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Wafi.BusReservationSystem.Domain.Entities;
using Wafi.BusReservationSystem.Domain.Enums;

namespace Wafi.BusReservationSystem.Infrastructure.Data
{
    public class WafiDbContext : DbContext
    {
        public WafiDbContext(DbContextOptions<WafiDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<City>().HasData(
                new City
                {
                    Id = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF"),
                    Name = "Dhaka"
                },
                new City
                {
                    Id = Guid.Parse("C85C3F39-AB09-43B1-9B5C-32D7E420F9A1"),
                    Name = "Rajshahi"
                },
                new City
                {
                    Id = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                    Name = "Sirajgonj"
                },
                new City
                {
                    Id = Guid.Parse("4DB86802-9AEA-4E7E-801A-B05A2463BE39"),
                    Name = "Khulna"
                }
            );

            builder.Entity<Bus>().HasData(
                new Bus
                {
                    Id = Guid.Parse("A2B7E02C-0382-4F4F-9F88-EB2A6E0C27F8"),
                    Name = "Green Line Express",
                    CompanyName = "Green Line Paribahan",
                    TotalSeats = 40,
                    BusType = BusType.AC
                },
                new Bus
                {
                    Id = Guid.Parse("AEE2A129-1088-405D-9E02-7B78BAE81BA1"),
                    Name = "Hanif Enterprise",
                    CompanyName = "Hanif Paribahan",
                    TotalSeats = 36,
                    BusType = BusType.Non_AC
                }
            );

            builder.Entity<Route>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasMany(r => r.DroppingPoints)
                    .WithOne(dp => dp.Route)
                    .HasForeignKey(dp => dp.RouteId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(r => r.BusSchedules)
                    .WithOne(s => s.Route)
                    .HasForeignKey(s => s.RouteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Route>().HasData(
                new Route
                {
                    Id = Guid.Parse("B3C689F4-4C78-4A7C-9023-3B91A15519A0"),
                    Name = "Dhaka to Rajshahi",
                    BoardingPointId = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF"),
                    DroppingPointId = Guid.Parse("C85C3F39-AB09-43B1-9B5C-32D7E420F9A1")
                },
                new Route
                {
                    Id = Guid.Parse("D0BE67E9-292E-4B0C-8C0D-1BB0A1E2E1A1"),
                    Name = "Rajshahi to Dhaka",
                    BoardingPointId = Guid.Parse("C85C3F39-AB09-43B1-9B5C-32D7E420F9A1"),
                    DroppingPointId = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF")
                }
            );

            builder.Entity<RouteDroppingPoint>(b =>
            {
                b.HasKey(x => x.Id);

                b.HasOne(dp => dp.City)
                    .WithMany(c => c.DroppingPoints)
                    .HasForeignKey(rs => rs.CityId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<RouteDroppingPoint>().HasData(
                new RouteDroppingPoint
                {
                    Id = Guid.Parse("EAB6B539-1981-460D-A0E1-7EE4A53B1299"),
                    RouteId = Guid.Parse("B3C689F4-4C78-4A7C-9023-3B91A15519A0"),
                    CityId = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF"),
                    DroppingPointsOrder = 1,
                    ArrivalTime = new TimeSpan(7, 0, 0),
                    DepartureTime = new TimeSpan(7, 15, 0)
                },
                new RouteDroppingPoint
                {
                    Id = Guid.Parse("BF14E6D2-BA55-4FBB-AC59-48A5F8A6407A"),
                    RouteId = Guid.Parse("B3C689F4-4C78-4A7C-9023-3B91A15519A0"),
                    CityId = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                    DroppingPointsOrder = 2,
                    ArrivalTime = new TimeSpan(9, 30, 0),
                    DepartureTime = new TimeSpan(9, 45, 0)
                },
                new RouteDroppingPoint
                {
                    Id = Guid.Parse("C318AFAC-EE1A-43BA-97F1-79ACBD78D2A5"),
                    RouteId = Guid.Parse("B3C689F4-4C78-4A7C-9023-3B91A15519A0"),
                    CityId = Guid.Parse("C85C3F39-AB09-43B1-9B5C-32D7E420F9A1"),
                    DroppingPointsOrder = 3,
                    ArrivalTime = new TimeSpan(12, 0, 0),
                    DepartureTime = new TimeSpan(12, 15, 0)
                }
            );

            builder.Entity<BusSchedule>(b =>
            {
                b.HasKey(x => x.Id);

                b.Property(b => b.JourneyDate)
                .HasColumnType("timestamp without time zone");

                b.HasOne(s => s.Bus)
                    .WithMany(bu => bu.Schedules)
                    .HasForeignKey(s => s.BusId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasMany(s => s.Seats)
                    .WithOne(se => se.BusSchedule)
                    .HasForeignKey(se => se.BusScheduleId)
                    .OnDelete(DeleteBehavior.Cascade);

                b.HasMany(s => s.Tickets)
                    .WithOne(t => t.BusSchedule)
                    .HasForeignKey(t => t.BusScheduleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<BusSchedule>().HasData(
                new BusSchedule
                {
                    Id = Guid.Parse("E5B270AF-9491-4B8D-953E-126AA36820B7"),
                    RouteId = Guid.Parse("B3C689F4-4C78-4A7C-9023-3B91A15519A0"),
                    BusId = Guid.Parse("A2B7E02C-0382-4F4F-9F88-EB2A6E0C27F8"),
                    JourneyDate = new DateTime(2025, 10, 30),
                    DepartureTime = new TimeSpan(7, 0, 0),
                    ArrivalTime = new TimeSpan(12, 0, 0),
                    Price = 800
                },
                new BusSchedule
                {
                    Id = Guid.Parse("8A21B9E8-BAEE-4A3E-AE0B-9AB1C812F268"),
                    RouteId = Guid.Parse("D0BE67E9-292E-4B0C-8C0D-1BB0A1E2E1A1"),
                    BusId = Guid.Parse("AEE2A129-1088-405D-9E02-7B78BAE81BA1"),
                    JourneyDate = new DateTime(2025, 10, 31),
                    DepartureTime = new TimeSpan(8, 0, 0),
                    ArrivalTime = new TimeSpan(13, 30, 0),
                    Price = 700
                }
            );

            builder.Entity<Passenger>().HasData(
                new Passenger
                {
                    Id = Guid.Parse("B1AA236B-9611-4E2C-8157-64A4BE53C3AD"),
                    Name = "Sabbir Ahmed",
                    MobileNumber = "01776913524"
                },
                new Passenger
                {
                    Id = Guid.Parse("D31771D2-0C5E-4E1F-92F0-4D68C6E3123F"),
                    Name = "Hasan Tarik",
                    MobileNumber = "01976913524"
                }
            );

            builder.Entity<Seat>().HasData(
                new Seat
                {
                    Id = Guid.Parse("B6D30D3E-8C67-4B83-86D5-1F47F0A22D2B"),
                    BusScheduleId = Guid.Parse("E5B270AF-9491-4B8D-953E-126AA36820B7"),
                    SeatNumber = "A1",
                    Row = 1,
                    Column = 1,
                    Status = SeatStatus.Available
                },
                new Seat
                {
                    Id = Guid.Parse("9B8B9A8C-8234-4A1E-9E5E-BA0F41A36C8F"),
                    BusScheduleId = Guid.Parse("E5B270AF-9491-4B8D-953E-126AA36820B7"),
                    SeatNumber = "A2",
                    Row = 1,
                    Column = 2,
                    Status = SeatStatus.Booked
                }
            );

            builder.Entity<Ticket>(b =>
            {
                b.HasKey(x => x.Id);

                b.Property(b => b.BookingTime)
                .HasColumnType("timestamp without time zone");

                b.HasOne(t => t.Seat)
                    .WithOne(se => se.Ticket)
                    .HasForeignKey<Ticket>(t => t.SeatId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne(t => t.Passenger)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(t => t.PassengerId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne<RouteDroppingPoint>()
                    .WithMany()
                    .HasForeignKey(t => t.BoardingPointId)
                    .OnDelete(DeleteBehavior.Restrict);

                b.HasOne<RouteDroppingPoint>()
                    .WithMany()
                    .HasForeignKey(t => t.DroppingPointId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Id = Guid.Parse("AAEF5D47-7C32-48AA-9C0D-0ACB03B6E2D9"),
                    BusScheduleId = Guid.Parse("E5B270AF-9491-4B8D-953E-126AA36820B7"),
                    PassengerId = Guid.Parse("B1AA236B-9611-4E2C-8157-64A4BE53C3AD"),
                    SeatId = Guid.Parse("9B8B9A8C-8234-4A1E-9E5E-BA0F41A36C8F"),
                    BoardingPointId = Guid.Parse("EAB6B539-1981-460D-A0E1-7EE4A53B1299"),
                    DroppingPointId = Guid.Parse("BF14E6D2-BA55-4FBB-AC59-48A5F8A6407A"),
                    BookingTime = new DateTime(2025, 10, 25, 14, 30, 0),
                    Status = TicketStatus.Confirmed,
                     Fare = 500
                },
                new Ticket
                {
                    Id = Guid.Parse("59F72A9F-0561-4B9F-8E7B-965F899B9E90"),
                    BusScheduleId = Guid.Parse("E5B270AF-9491-4B8D-953E-126AA36820B7"),
                    PassengerId = Guid.Parse("D31771D2-0C5E-4E1F-92F0-4D68C6E3123F"),
                    SeatId = Guid.Parse("B6D30D3E-8C67-4B83-86D5-1F47F0A22D2B"),
                    BoardingPointId = Guid.Parse("BF14E6D2-BA55-4FBB-AC59-48A5F8A6407A"),
                    DroppingPointId = Guid.Parse("C318AFAC-EE1A-43BA-97F1-79ACBD78D2A5"),
                    BookingTime = new DateTime(2025, 10, 26, 15, 0, 0),
                    Status = TicketStatus.Pending,
                    Fare = 300
                }
            );
            base.OnModelCreating(builder);
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteDroppingPoint> RouteDroppingPoints { get; set; }
        public DbSet<BusSchedule> BusSchedules { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
    }
}
