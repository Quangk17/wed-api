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
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookingTypeRepository, BookingTypeRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();

            services.AddScoped<IBookingTypeService, BookingTypeService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IBookingDetailService, BookingDetailService>();
            services.AddScoped<IInvoiceService, InvoiceService>();





            services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddScoped<IGenericRepository<Store>, GenericRepository<Store>>();
            services.AddScoped<IGenericRepository<Court>, GenericRepository<Court>>();
            services.AddScoped<IGenericRepository<Booking>, GenericRepository<Booking>>();
            services.AddScoped<IGenericRepository<BookingDetail>, GenericRepository<BookingDetail>>();
            services.AddScoped<IGenericRepository<BookingType>, GenericRepository<BookingType>>();
            services.AddScoped<IGenericRepository<CheckingStaff>, GenericRepository<CheckingStaff>>();
            services.AddScoped<IGenericRepository<Invoice>, GenericRepository<Invoice>>();
            services.AddScoped<IGenericRepository<Wallet>, GenericRepository<Wallet>>();
            services.AddScoped<IGenericRepository<Slot>, GenericRepository<Slot>>();
            services.AddScoped<IGenericRepository<Schedule>, GenericRepository<Schedule>>();





            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ICurrentTime, CurrentTime>();
            services.AddAutoMapper(typeof(MapperConfigurationsProfile).Assembly);
            return services;
        }
    }
}
