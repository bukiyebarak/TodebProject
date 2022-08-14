using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EF
{
    public class EFMessageRepository : EFBaseRepository<Message, TodebDbContext>, IMessageRepository
    {
        public EFMessageRepository(TodebDbContext context) : base(context)
        {
        }
    }
}
