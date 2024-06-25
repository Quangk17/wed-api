using Application.Commons;
using Application.ViewModels.AccountDTOs;

using Application.ViewModels.CourtDTOs;
using Application.ViewModels.RoleDTOs;
using Application.ViewModels.ScheduleDTOs;
using Application.ViewModels.SlotDTOs;
using Application.ViewModels.StoreDTOs;

using Application.ViewModels.BookingDTOs;
using Application.ViewModels.BookingTypeDTOs;
using Application.ViewModels.InvoiceDTOs;

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
            // mapping viewdto
            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<Store, StoreDTO>().ReverseMap();

            CreateMap<Court, CourtDTO>().ReverseMap();

            CreateMap<Slot, SlotDTO>().ReverseMap();

            CreateMap<Schedule, ScheduleDTO>().ReverseMap();

            CreateMap(typeof(Pagination<>), typeof(Pagination<>));

            // mapping createdto
            CreateMap<RoleCreateDTO, Role>().ReverseMap();
            CreateMap<StoreCreateDTO, Store>().ReverseMap();
            CreateMap<CourtCreateDTO, Court>().ReverseMap();
            CreateMap<ScheduleCreateDTO, Schedule>().ReverseMap();
            CreateMap<SlotCreateDTO, Slot>().ReverseMap();

            //  mapping updatedto
            CreateMap<RoleUpdateDTO, Role>().ReverseMap();
            CreateMap<StoreUpdateDTO, Store>().ReverseMap();
            CreateMap<CourtUpdateDTO, Court>().ReverseMap();
            CreateMap<ScheduleUpdateDTO, Schedule>().ReverseMap();
            CreateMap<SlotUpdateDTO, Slot>().ReverseMap();








        }

    }
}
