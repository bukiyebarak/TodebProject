using AutoMapper;
using BackgroundJobs.Abstract;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.Message;
using DAL.Abstract;
using DTO.Message;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private IMapper _mapper;
       
        public MessageService(IMessageRepository messageRepository, IMapper mapper, IJobs jobs)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            
        }

        public CommandResponse Delete(DeleteMessageRequest message)
        {
            var entity = _mapper.Map<Message>(message);
            
            _messageRepository.Delete(entity);
            _messageRepository.SaveChanges();
            return new CommandResponse
            {
                Status = true,
                Messsage = $"Mesaj Silindi.",

            };
        }


        //Mesajlar toplu olarak çekilecek
        public IEnumerable<Message> GetAll()
        {
            return _messageRepository.GetAll();
        }

        public CommandResponse Insert(CreateMessageRequest message)
        {
            var validator = new CreateMessageRequestValidator();
            validator.Validate(message).ThrowIfException();
            var entity = _mapper.Map<Message>(message);

            _messageRepository.Add(entity);
            _messageRepository.SaveChanges();
            return new CommandResponse
            {
                Status = true,
                Messsage = $"Mesaj Gönderildi.",

            };
        }
    }
}
