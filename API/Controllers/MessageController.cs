using Business.Abstract;
using DTO.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(CreateMessageRequest message)
        {
            var response = _service.Insert(message);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteMessageRequest message)
        {
            var response = _service.Delete(message);
            return Ok(response);
        }
    }
}
