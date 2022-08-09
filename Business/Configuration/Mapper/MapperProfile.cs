using AutoMapper;
using DTO.Apartment;
using DTO.Bill;
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
            CreateMap<CreateApartmentRequest, Home>();
            CreateMap<UpdateApartmentRequest, Home>();
            CreateMap<DeleteApartmentRequest, Home>();
            CreateMap<CreateBillRequest, Bill>();
            CreateMap<UpdateBillRequest, Bill>();
            CreateMap<DeleteBillRequest, Bill>();
        }
    }
}
