using AutoMapper;
using DTO.Apartment;
using DTO.Order;
using DTO.User;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateOrderRequest, Order>();
            CreateMap<UpdateOrderRequest, Order>();
            CreateMap<CreateUserRegisterRequest, User>();
            CreateMap<CreateApartmentRequest, Apartment>();
            CreateMap<UpdateApartmentRequest, Apartment>();
            CreateMap<DeleteApartmentRequest, Apartment>();
        }
    }
}
