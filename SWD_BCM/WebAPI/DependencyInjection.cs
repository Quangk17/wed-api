using System.Diagnostics;
using WebAPI.Middlewares;
using FluentValidation.AspNetCore;
using Application.Interfaces;
using Application;
using Infrastructures;
using WebAPI.Service;
using Infrastructures.Mappers;
using Application.Services;
using Application.Repositories;
using Infrastructures.Repositories;
using Application.Repositorys;
using Domain.Entites;
namespace WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebAPIService(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddSingleton<GlobalExceptionMiddleware>();
            services.AddSingleton<PerformanceMiddleware>();
            services.AddSingleton<Stopwatch>();
            services.AddHttpContextAccessor();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddMemoryCache();
            // infrastructure service
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // controller API  service
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ICourtService, CourtService>();

            services.AddScoped<ISlotService, SlotService>();
            services.AddScoped<IScheduleService, ScheduleService>();





            return services;
        }

    }
}
