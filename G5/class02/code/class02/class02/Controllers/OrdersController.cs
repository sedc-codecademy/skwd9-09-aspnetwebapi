using class02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace class02.Controllers
{
    //route https://localhost:5001/api/orders
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET

        //route: https://localhost:5001/api/orders/get
        [HttpGet]
        [Route("Get")]
        public IActionResult Get() 
        {
            return Ok();
        }

        //route: https://localhost:5001/api/orders/getwithoneparameter/5
        [HttpGet]
        [Route("GetWithOneParameter/{id}")]
        public IActionResult GetWithOneParameter(int id) 
        {
            var response = id;
            return BadRequest();
        }

        //route: https://localhost:5001/api/orders/1/userid/5
        [HttpGet]
        [Route("GetWithManyParameters/{id}/userid/{userId}")]
        public IActionResult GetWithManyParameters(int id, int userId) 
        {
            return Ok();
        }

        //route: https://localhost:5001/api/orders/GetWithOne/5
        [HttpGet("GetWithOne/{id}")]
        public IActionResult GetWithOne([FromRoute]int id)
        {
            return Ok();
        }

        //route https://localhost:5001/api/orders/GetWithQueryParameters?id=3&userId=12
        [HttpGet]
        [Route("GetWithQueryParameters")]
        public IActionResult GetWithQueryParameters([FromQuery]int id, [FromQuery]int userId) 
        {
            return Ok();
        }

        //route https://localhost:5001/api/orders/GetWithCombineParameters/5/order/3?pageNumber=6
        [HttpGet]
        [Route("GetWithCombineParameters/{id}/order/{orderId}")]
        public IActionResult GetWithCombineParameters([FromRoute] int id,
                                                      [FromRoute] int orderId, 
                                                      [FromQuery] int pageNumber) 
        {
            return Ok();
        }

        // DELETE

        //route: https://localhost:5001/api/orders/delete
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete() 
        {
            return Ok();
        }

        //route: https://localhost:5001/api/orders/delete
        [HttpGet]
        [Route("delete")]
        public IActionResult DeleteGet()
        {
            return Ok();
        }

        //route: https://localhost:5001/api/orders/delete/5?name=viktor
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteWithParameters([FromRoute] int id, [FromQuery] string name) 
        {
            return Ok();
        }

        // POST

        //route: https://localhost:5001/api/orders/post
        [HttpPost]
        [Route("post")]
        public IActionResult Post() 
        {
            return Ok();
        }


        //route: https://localhost:5001/api/orders/PostWithBody
        [HttpPost]
        [Route("PostWithBody")]
        public IActionResult PostWithBody([FromBody] Order order)
        {
            // call some order service
            // write the order in to the database...
            return Ok(order);
        }

        //route: https://localhost:5001/api/orders/PostWithHeader
        [HttpPost]
        [Route("PostWithHeader")]
        public IActionResult PostWithHeader([FromHeader] string token)
        {
            return Ok(token);
        }


        //route: https://localhost:5001/api/orders/PostWithEverything/1?userId=2
        [HttpPost]
        [Route("PostWithEverything/{id}")]
        public IActionResult PostWithEverything([FromRoute] int id, 
                                                [FromQuery] int userId,     
                                                [FromHeader] string token,
                                                [FromBody] Order order) 
        {
            return Ok();
        }

        //PUT

        //route: https://localhost:5001/api/orders/Put/1
        [HttpPut]
        [Route("Put/{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Order order) 
        {
            return Ok();
        }

        //RESPONSES
        [HttpGet]
        [Route("Responses")]
        public IActionResult Responses() 
        {
            return new EmptyResult();

            var order = new Order();

            return Ok(order);
            return Ok("The user is created!");

            return BadRequest();
            return BadRequest(new { message = "Try again" });

            return NotFound();
            return NotFound(new { message = "Try again", suggestion = 1 });

            return StatusCode(StatusCodes.Status200OK, new { message = "Try again", suggestion = 1 });
            return StatusCode(StatusCodes.Status400BadRequest);
            return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(StatusCodes.Status401Unauthorized);
        }

    }
}
