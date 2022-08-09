using DAL.EFBase;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    //IApartmentRepository'i IEFBaseRepository'den implement edildi. Böylece Ekleme silme vb. gibi özellikler IEFBaseRepositroy'den enjekte olacak.
    public interface IApartmentRepository:IEFBaseRepository<Home>
    {
    }
}
