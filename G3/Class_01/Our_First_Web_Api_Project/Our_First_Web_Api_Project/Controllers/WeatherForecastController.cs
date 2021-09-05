using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Our_First_Web_Api_Project.Controllers
{
    [ApiController]
    [Route("/products")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        public List<string> Get()
        {
            return new List<string>() { "Web", "Api", "G3" };
        }
    }
}
