using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("strings")]
        public ActionResult<IEnumerable<string>> GetStrings()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("integer")]
        public ActionResult<int> GetInteger()
        {
            return 5;
        }
    }
}
