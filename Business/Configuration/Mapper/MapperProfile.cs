using AutoMapper;
using DTO.Apartment;
using DTO.Bill;
using DTO.Message;
using DTO.User;
using Models.Entities;
using System.Linq;

namespace Business.Configuration.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
           
            
            CreateMap<CreateApartmentRequest, Home>();
            CreateMap<UpdateApartmentRequest, Home>();
            CreateMap<DeleteApartmentRequest, Home>();
            CreateMap<CreateBillRequest, Bill>();
            CreateMap<UpdateBillRequest, Bill>();
            CreateMap<DeleteBillRequest, Bill>();
            CreateMap<CreateMessageRequest, Message>();
            CreateMap<DeleteMessageRequest, Message>(); 
            CreateMap<CreateUserRegisterRequest, User>().ForMember(x => x.Permissions,
                a => a.MapFrom(c => c.UserPermissions.Select(b =>
                    new UserPermission()
                    {
                        Permission = b
                    })));
        }
    }
}
