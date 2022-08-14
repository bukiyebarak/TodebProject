using AutoMapper;
using DTO.Apartment;
using DTO.Bill;
using DTO.Message;
using DTO.User;
using Models.Entities;

namespace Business.Configuration.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
           
            CreateMap<CreateUserRegisterRequest, User>();
            CreateMap<CreateApartmentRequest, Home>();
            CreateMap<UpdateApartmentRequest, Home>();
            CreateMap<DeleteApartmentRequest, Home>();
            CreateMap<CreateBillRequest, Bill>();
            CreateMap<UpdateBillRequest, Bill>();
            CreateMap<DeleteBillRequest, Bill>();
            CreateMap<CreateMessageRequest, Message>();
            CreateMap<DeleteMessageRequest, Message>();
        }
    }
}
