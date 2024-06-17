using Application;
using Application.Interfaces;
using Application.Repositories;
using Application.Services;
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
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<IBookingTypeService, BookingTypeService>();
            services.AddScoped<IBookingTypeRepository, BookingTypeRepository>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();

            services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
            services.AddScoped<IBookingDetailService, BookingDetailService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ICurrentTime, CurrentTime>();


            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(databaseConnection));
            services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);
            return services;
        }
    }
}
