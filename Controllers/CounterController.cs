using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProject.Services.Abstractions;

namespace WebProject.Controllers
{
    [ApiController]
    [Route("api/v1/controller")]
    public class CounterController : ControllerBase
    {
        private readonly ICounterService _counterService;

        public CounterController([FromServices] ICounterService counterService)
        {
            _counterService = counterService;
        }

        [HttpGet("increase")]
        public ActionResult IncreaseCounter()
        {
            var counter1 = _counterService.IncreaseCounter(); // 1 new instrance if transient
            var counter2 = _counterService.IncreaseCounter();
            var counter3 = _counterService.IncreaseCounter();
            return 
        }
        
    }
}