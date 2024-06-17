﻿using Application.Commons;
using Application.ViewModels.AccountDTOs;
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

            CreateMap(typeof(Pagination<>), typeof(Pagination<>));
        }

    }
}
