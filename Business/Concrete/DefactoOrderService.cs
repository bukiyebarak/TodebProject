using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation;
using DAL.Abstract;
using DTO.Order;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class DefactoOrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private IMapper _mapper;

        public DefactoOrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public CommandResponse Delete(Order order)
        {
            _orderRepository.Delete(order);
            return new CommandResponse
            {
                Status = true,
                Messsage = $"Siparişiniz silindi. Id={order.Id}",
            };
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public CommandResponse Insert(CreateOrderRequest order)
        {
            var validator = new CreateDefatoOrderRequestValidator();
            validator.Validate(order).ThrowIfException();
            var entity = _mapper.Map<Order>(order);

            _orderRepository.Add(entity);

            return new CommandResponse
            {
                Status = true,
                Messsage = $"Siparişiniz eklendi",
            };
        }

        public CommandResponse Update(UpdateOrderRequest order)
        {
            var validator = new UpdateOrderRequestValidator();
            validator.Validate(order).ThrowIfException();

            var entity = _orderRepository.Get(x=>x.Id==order.Id);
            if (entity == null)
            {
                return new CommandResponse()
                {
                    Status = false,
                    Messsage = "Veri tabanında bu Id de kayıt bulunmamaktadır"
                };
            }
            var mappedEntity = _mapper.Map(order, entity);

            _orderRepository.Update(mappedEntity);

            return new CommandResponse
            {
                Status = true,
                Messsage = $"Siparişiniz güncellendi. Id={order.Id}",
            };
        }
    }
}
