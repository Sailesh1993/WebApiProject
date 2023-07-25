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
        public int IncreaseCounter()
        {
           return _counterService.IncreaseCounter();
        }
        
    }
}