using DAL.EFBase;
using Models.Entities;

namespace DAL.Abstract
{
    public interface IUserRepository: IEFBaseRepository<User>
    {
        //interface'ler default olarak public alır.
        User GetUserWithPassword(string email);
    }
}
