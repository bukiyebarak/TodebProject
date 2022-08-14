using Business.Abstract;
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
    public class CacheController : ControllerBase
    {
        private readonly ICacheExample _cacheExample;

        public CacheController(ICacheExample cacheExample)
        {
            _cacheExample = cacheExample;
        }

        [HttpPost]
        public IActionResult Post()
        {
            _cacheExample.DistSetString("TestKey", "TestValue");
            return Ok();
        }

        [HttpPost("SetList")]
        public IActionResult SetList()
        {
            _cacheExample.DistSetList("TestKeyList");
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<string>();
            list.Add(_cacheExample.DistGetValue("TestKey"));
            list.Add(_cacheExample.DistGetValue("TestKeyList"));

            return Ok(list);
        }


        [HttpPost("InMemoryTest")]
        public IActionResult InMemoryTest()
        {
            _cacheExample.InMemSetString("InMemoryStr", "InMemoryStrExample");
            _cacheExample.InMemSetObject("InMemoryList", new int[] { 1, 3, 9, 81});
            return Ok();

        }

        [HttpGet("GetInMemory")]
        public IActionResult GetInMemory()
        {
            var strValue = _cacheExample.InMemGetValue<string>("InMemoryStr");
            var listValue = _cacheExample.InMemGetValue<int[]>("InMemoryList");

            return Ok(new { strValue, listValue });
        }
    }
}
