using Autofac;
using Wafi.BusReservationSystem.Application;
using Wafi.BusReservationSystem.Application.Contracts.Interfaces;
using Wafi.BusReservationSystem.Application.Services;
using Wafi.BusReservationSystem.Domain.RepositoryContracts;
using Wafi.BusReservationSystem.Infrastructure.Data;
using Wafi.BusReservationSystem.Infrastructure.Repositories;
using Wafi.BusReservationSystem.Infrastructure.UnitOfWorks;

namespace Wafi.BusReservationSystem.Web
{
    public class WebModule(string connectionString, string migrationAssembly) : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WafiDbContext>().AsSelf()
                .WithParameter("connectionString", connectionString)
                .WithParameter("migrationAssembly", migrationAssembly)
                .InstancePerLifetimeScope();

            builder.RegisterType<BusReservationSystemUnitOfWork>()
                .As<IBusReservationSystemUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CityRepository>()
                .As<ICityRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CityService>()
                .As<ICityService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BusRepository>()
                .As<IBusRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BusService>()
                .As<IBusService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RouteRepository>()
                .As<IRouteRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RouteService>()
                .As<IRouteService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RouteDroppingPointRepository>()
                .As<IRouteDroppingPointRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
