using Business.Configuration.Response;
using DTO.Message;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        public IEnumerable<Message> GetAll();
        public CommandResponse Insert(CreateMessageRequest message);
        public CommandResponse Delete(DeleteMessageRequest message);
    }
}
