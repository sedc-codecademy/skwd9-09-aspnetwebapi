using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]   //http://localhost:[port]/api/values
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet] //http://localhost:[port]/api/values
        public ActionResult<List<string>> Get()
        {
            return new List<string> { "value1", "value2" };
        }

        [HttpGet("{id}")] //http://localhost:[port]/api/values/1
        public ActionResult<string> Get(int id)
        {
            return "value1";
        }

        [HttpGet("details/{id}")] //http://localhost:[port]/api/values/details/1
        public ActionResult<string> Details(int id)
        {
            return "value2";
        }

        [HttpPost]
        public ActionResult<string> PostAction([FromBody] string text)
        {
            return "Ok";
        }
    }
}
