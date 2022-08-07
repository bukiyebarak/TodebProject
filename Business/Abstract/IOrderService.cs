using Business.Configuration.Response;
using DTO.Order;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        public IEnumerable<Order> GetAll();
        public CommandResponse Insert(CreateOrderRequest order);
        public CommandResponse Update(UpdateOrderRequest order);
        public CommandResponse Delete(Order order);

    }
}
