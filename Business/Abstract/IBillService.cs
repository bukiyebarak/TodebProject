using Business.Configuration.Response;
using DTO.Bill;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBillService
    {
        public IEnumerable<Bill> GetAll();
        public CommandResponse Insert(CreateBillRequest bill);
        public CommandResponse Update(UpdateBillRequest bill);
        public CommandResponse Delete(DeleteBillRequest bill);
    }
}
