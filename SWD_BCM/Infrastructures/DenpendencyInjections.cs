using Application;
using Application.Interfaces;
using Application.Repositories;
using Application.Repositorys;
using Application.Services;
using Domain.Entites;
using Infrastructures.Mappers;
using Infrastructures.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace Infrastructures
{
    public static class DenpendencyInjections
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, string databaseConnection)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(databaseConnection));

            //add repositories injection
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ICourtRepository, CourtRepository>();
            services.AddScoped<ISlotRepository, SlotRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();





            services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IGenericRepository<Store>, GenericRepository<Store>>();
            services.AddScoped<IGenericRepository<Court>, GenericRepository<Court>>();

            services.AddScoped<IGenericRepository<Slot>, GenericRepository<Slot>>();
            services.AddScoped<IGenericRepository<Schedule>, GenericRepository<Schedule>>();






            services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);
            return services;
        }
    }
}
