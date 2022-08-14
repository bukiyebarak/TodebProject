using Business.Abstract;
using DTO.Bill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _service;

        public BillController(IBillService service)
        {
            _service = service;
        }

        //tüm kullanılacılara erişim izni verilir.
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(CreateBillRequest bill)
        {
            var response = _service.Insert(bill);
            return Ok(response);
        }

      
        [HttpPut]
        public IActionResult Put(UpdateBillRequest  bill)
        {
            var response = _service.Update(bill);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(DeleteBillRequest bill)
        {
            var response = _service.Delete(bill);
            return Ok(response);
        }

        
    }
}
