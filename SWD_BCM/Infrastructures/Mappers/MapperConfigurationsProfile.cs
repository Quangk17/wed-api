using Application.Commons;
using Application.ViewModels.AccountDTOs;
<<<<<<< HEAD
using Application.ViewModels.CourtDTOs;
using Application.ViewModels.RoleDTOs;
using Application.ViewModels.ScheduleDTOs;
using Application.ViewModels.SlotDTOs;
using Application.ViewModels.StoreDTOs;
=======
using Application.ViewModels.BookingDTOs;
using Application.ViewModels.BookingTypeDTOs;
using Application.ViewModels.InvoiceDTOs;
>>>>>>> d1d00f5fbf5b12f9ea15223702e3ebf0824a8210
using AutoMapper;
using Domain.Entites;


namespace Infrastructures.Mappers
{
    public class MapperConfigurationsProfile : Profile
    {
        public MapperConfigurationsProfile()
        {
            CreateMap<User, AccountDTO>().ReverseMap();
            CreateMap<User, AuthenAccountDTO>().ReverseMap();
            CreateMap<User, RegisterAccountDTO>().ReverseMap();
            CreateMap<User, AccountUpdateDTO>().ReverseMap();

            CreateMap<Booking, BookingViewDTO>().ReverseMap();
            CreateMap<Booking, BookingCreateDTO>().ReverseMap();
            CreateMap<Booking, BookingUpdateDTO>().ReverseMap();

            CreateMap<BookingType, BookingTypeViewDTO>().ReverseMap();
            CreateMap<BookingType, BookingTypeCreateDTO>().ReverseMap();
            CreateMap<BookingType, BookingTypeUpdateDTO>().ReverseMap();

            CreateMap<Invoice, InvoiceViewDTO>().ReverseMap();
            CreateMap<Invoice, InvoiceCreateDTO>().ReverseMap();
            CreateMap<Invoice, InvoiceUpdateDTO>().ReverseMap();

            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<Store, StoreDTO>().ReverseMap();

            CreateMap<Court, CourtDTO>().ReverseMap();

            CreateMap<Slot, SlotDTO>().ReverseMap();

            CreateMap<Schedule, ScheduleDTO>().ReverseMap();

            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            
        }

    }
}
