using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation;
using DAL.Abstract;
using DTO.Order;
using FluentValidation;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private IMapper _mapper;
        private IJobs _jobs;
        public OrderService(IOrderRepository orderRepository, IMapper mapper, IJobs jobs)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _jobs = jobs;
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
            var validator = new CreateOrderRequestValidator();
            validator.Validate(order).ThrowIfException();
            var entity = _mapper.Map<Order>(order);

            _orderRepository.Add(entity);
            _orderRepository.SaveChanges();

            _jobs.DelayedJob(entity.Id, entity.Name, TimeSpan.FromSeconds(15));
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

            var entity = _orderRepository.Get(x => x.Id == order.Id);
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
            _orderRepository.SaveChanges();

            //if (valid.IsValid == false)
            //{
            //    var message = string.Join(',', valid.Errors.Select(x => x.ErrorMessage));
            //    throw new ValidationException(message);
            //}
            return new CommandResponse
            {
                Status = true,
                Messsage = $"Siparişiniz güncellendi. Id={order.Id}",
            };
        }
    }
}
