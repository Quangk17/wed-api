using Application.Commons;
using Application.ViewModels.AccountDTOs;
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

            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
        }

    }
}
