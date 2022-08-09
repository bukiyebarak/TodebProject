using Business.Abstract;
using DTO.Apartment;
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
    public class HomeController : ControllerBase
    {
        private readonly IApartmentService _service;

        public HomeController(IApartmentService apartmentService)
        {
            _service = apartmentService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(CreateApartmentRequest apartment)
        {
            var response = _service.Insert(apartment);
            return Ok(response);
        }



        [HttpPut]
        public IActionResult Put(UpdateApartmentRequest apartment)
        {
            var response = _service.Update(apartment);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteApartmentRequest apartment)
        {
            var response = _service.Delete(apartment);
            return Ok(response);
        }
    }
}
