using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EF
{
    public class EFApartmentRepository : EFBaseRepository<Apartment, TodebDbContext>, IApartmentRepository
    {
        public EFApartmentRepository(TodebDbContext context) : base(context)
        {
        }

        public Apartment GetUser(int userId)
        {
            //include join işlemi yapar
            return Context.Apartments
                .Include(x => x.User)
                .FirstOrDefault(x => x.UserId == userId);

        }

    }
}
