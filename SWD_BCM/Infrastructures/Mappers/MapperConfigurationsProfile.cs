using Application.Commons;
using Application.ViewModels.AccountDTOs;
using Application.ViewModels.CourtDTOs;
using Application.ViewModels.RoleDTOs;
using Application.ViewModels.ScheduleDTOs;
using Application.ViewModels.SlotDTOs;
using Application.ViewModels.StoreDTOs;
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

            CreateMap<Role, RoleDTO>().ReverseMap();

            CreateMap<Store, StoreDTO>().ReverseMap();

            CreateMap<Court, CourtDTO>().ReverseMap();

            CreateMap<Slot, SlotDTO>().ReverseMap();

            CreateMap<Schedule, ScheduleDTO>().ReverseMap();

            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
            
        }

    }
}
