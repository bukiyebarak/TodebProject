using Business.Configuration.Response;
using DTO.User;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        CommandResponse Register(CreateUserRegisterRequest register);
        IEnumerable<User> GetAll();

    }
}
