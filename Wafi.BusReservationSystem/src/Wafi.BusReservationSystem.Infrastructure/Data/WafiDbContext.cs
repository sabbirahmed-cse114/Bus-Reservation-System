using Microsoft.EntityFrameworkCore;
using Wafi.BusReservationSystem.Domain.Entities;

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
            builder.Entity<City>().HasData
                (
                    new City
                    {
                        Id = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF"),
                        Name = "Dhaka"
                    },
                    new City
                    {
                        Id = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                        Name = "Sirajgonj"
                    },

                    new City
                    {
                        Id = Guid.Parse("24A44820-CFF8-4509-AA16-A1F4C5BB0BD5"),
                        Name = "Rajshahi"
                    },
                    new City
                    {
                        Id = Guid.Parse("4DB86802-9AEA-4E7E-801A-B05A2463BE39"),
                        Name = "Khulna"
                    }
                );
            builder.Entity<Bus>().HasData
                (
                    new Bus
                    {
                        Id = Guid.Parse("0FADBF4C-F8CF-4937-86A2-0CA33FEB33F9"),
                        CompanyName = "Hanif Enterprise",
                        BusName = "Hanif Volvo AC",
                        TotalSeats = 40
                    },
                    new Bus
                    {
                        Id = Guid.Parse("CEA979FD-08FD-4B38-B14A-B2518B481112"),
                        CompanyName = "ENA Enterprise",
                        BusName = "ENA Non AC",
                        TotalSeats = 36
                    },
                    new Bus
                    {
                        Id = Guid.Parse("81630E00-DF5D-4C49-A335-AAEB0E44A4D4"),
                        CompanyName = "Green Line Paribahan",
                        BusName = "Scania Business Class",
                        TotalSeats = 40
                    },
                    new Bus
                    {
                        Id = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                        CompanyName = "Hanif Enterprise",
                        BusName = "Hino non-AC",
                        TotalSeats = 34
                    }
                );
            builder.Entity<Route>()
                .HasOne(r => r.BoardingPointCity)
                .WithMany()
                .HasForeignKey(r => r.BoardingPointId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Route>().HasData
                (
                    new Route
                    {
                        Id = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                        BoardingPointId = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF"),
                        Order = 1,
                        Distance = 250,
                        DepartureTime = new TimeSpan(18,0,0)
                    },
                    new Route
                    {
                        Id = Guid.Parse("81630E00-DF5D-4C49-A335-AAEB0E44A4D4"),
                        BoardingPointId = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF"),
                        Order = 1,
                        Distance = 650,
                        DepartureTime = new TimeSpan(21, 0, 0)
                    }
                );

            builder.Entity<RouteDroppingPoint>().HasData
                (
                    new RouteDroppingPoint
                    {
                        Id = Guid.Parse("164DC434-D1C9-4220-88F0-407517F7434C"),
                        RouteId = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                        DroppingPointId = Guid.Parse("F91D9F76-694C-42D5-AFCA-69252DC86EFF"),
                        Order = 2,
                        Distance = 0,
                        ArrivalTime = new TimeSpan(7, 0, 0),
                        DepartureTime = new TimeSpan(8, 0, 0)
                    },
                    new RouteDroppingPoint
                    {
                        Id = Guid.Parse("a83f3b24-cb63-4ec4-bc80-ef4eaaba047d"),
                        RouteId = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                        DroppingPointId = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                        Order = 3,
                        Distance = 25,
                        ArrivalTime = new TimeSpan(10, 0, 0),
                        DepartureTime = new TimeSpan(10, 05, 0)
                    },
                    new RouteDroppingPoint
                    {
                        Id = Guid.Parse("4DB86802-9AEA-4E7E-801A-B05A2463BE39"),
                        RouteId = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                        DroppingPointId = Guid.Parse("24A44820-CFF8-4509-AA16-A1F4C5BB0BD5"),
                        Order = 4,
                        Distance = 50,
                        ArrivalTime = new TimeSpan(20, 0, 0),
                        DepartureTime = new TimeSpan(21, 0, 0)
                    }
                );

            builder.Entity<BusSchedule>()
                .Property(b => b.JourneyDate)
                .HasColumnType("timestamp without time zone");

            builder.Entity<BusSchedule>().HasData
                (
                    new BusSchedule
                    {
                        Id = Guid.Parse("164DC434-D1C9-4220-88F0-407517F7434C"),
                        BusId = Guid.Parse("0FADBF4C-F8CF-4937-86A2-0CA33FEB33F9"),
                        RouteId = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                        JourneyDate = new DateTime(2025, 10, 26),
                        DepartureTime = new TimeSpan(10, 0, 0),
                        ArrivalTime = new TimeSpan(8, 0, 0),
                        Price = 700
                    },
                    new BusSchedule
                    {
                        Id = Guid.Parse("a83f3b24-cb63-4ec4-bc80-ef4eaaba047d"),
                        BusId = Guid.Parse("81630E00-DF5D-4C49-A335-AAEB0E44A4D4"),
                        RouteId = Guid.Parse("81630E00-DF5D-4C49-A335-AAEB0E44A4D4"),
                        JourneyDate = new DateTime(2025,10, 26),
                        DepartureTime = new TimeSpan(20, 0, 0),
                        ArrivalTime = new TimeSpan(19,0,0),
                        Price = 1200
                    }
                );


            builder.Entity<Passenger>().HasData
                (
                    new Passenger
                    {
                        Id = Guid.Parse("39B76299-F549-4FC6-99A0-A15A607CB510"),
                        Name = "Sabbir Ahmed",
                        MobileNumber = "01976913524"
                    },
                    new Passenger
                    {
                        Id = Guid.Parse("81630E00-DF5D-4C49-A335-AAEB0E44A4D4"),
                        Name = "Hasan Tarik",
                        MobileNumber = "01776913524"
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
