using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [Route("query")]
        [HttpGet]
        public IActionResult QueryParamsTest([FromQuery] string name, [FromQuery] string lastname)
        {
            var test = Request.QueryString;
            var test2 = Request.Query.TryGetValue("lastname", out StringValues paramValue);
            return Ok(name);
        }

        [Route("query/{id}")]
        [HttpGet]
        public IActionResult QueryParamsTest([FromRoute] int id, [FromQuery] string name, [FromQuery] string lastname)
        {
            var test = Request.QueryString;
            var test2 = Request.Query.TryGetValue("lastname", out StringValues paramValue);
            return Ok(name);
        }

        [Route("color")]
        [HttpGet]
        public IActionResult ColorTest([FromQuery] List<string> colorList)
        {
            var colors = Request.Query["colorList"];
            return Ok(colorList);
        }

        [HttpPost("post")]
        public IActionResult PostTest([FromBody] Note note)
        {
            return Ok(note);
        }

        [HttpPost("postroute/{id}")]
        public IActionResult PostTestRoute([FromBody] Note note, [FromRoute] int id)
        {
            return Ok(note);
        }

        [HttpPost("postparams/{id}")]
        public IActionResult PostTestParams([FromBody] Note note, [FromQuery] int id)
        {
            return Ok(note);
        }

        [HttpPost("postmulti/{id}")]
        public IActionResult PostTestParams([FromBody] Note note, [FromRoute] int id, [FromQuery] int userId)
        {
            return Ok(note);
        }

        [HttpPost("postquery")]
        public IActionResult PostTestQuery([FromQuery] Note note)
        {
            return Ok(note);
        }

        [HttpGet("getheader")]
        public IActionResult GetHeaderTest([FromHeader] string host)
        {
            return Ok(host);
        }

        [HttpPost("postheader")]
        public IActionResult PostHeaderTest([FromHeader(Name = "Accept-Language")] string lang)
        {
            return Ok(lang);
        }

        [HttpGet("headercustomname")]
        public IActionResult GetHeaderNameCustomTest([FromHeader(Name = "Ljube")] string text)
        {
            return Ok(text);
        }

        [HttpGet("headercustom")]
        public IActionResult GetHeaderCustomTest([FromHeader] string ljube)
        {
            return Ok(ljube);
        }
    }
}
