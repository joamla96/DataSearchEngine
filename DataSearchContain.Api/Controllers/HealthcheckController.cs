using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataSearchContain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthcheckController : ControllerBase
    {
        // GET: api/Healthcheck
        [HttpGet]
        public IActionResult Get()
        {
			return Ok("I AM ALIVE"); // Yes. Do no work. Only to check if the instance is online.
        }
    
    }
}
