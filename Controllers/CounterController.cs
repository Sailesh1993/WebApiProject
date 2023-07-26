using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProject.Services.Abstractions;

namespace WebProject.Controllers
{
    [ApiController]
    [Route("api/v1/counter")]
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
            /* counter middleware : increase counter from 0 to 1 -> countercontroller: increase counter from 1 to 2 */
            /*  transient service: new instance inside middleware, new instance inside controller */
            var counter1 = _counterService.IncreaseCounter(); // 1 new instance if transient
            /* var counter2 = _counterService.IncreaseCounter();// 1 new instance if transient
            var counter3 = _counterService.IncreaseCounter();// 1 new instance if transient */
           return Ok(new{counter1});
        }
        
    }
}