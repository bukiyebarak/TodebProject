using DAL.EFBase;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IUserRepository: IEFBaseRepository<User>
    {
        //interface'ler default olarak public alır.
        User GetUserWithPassword(string email);
    }
}
