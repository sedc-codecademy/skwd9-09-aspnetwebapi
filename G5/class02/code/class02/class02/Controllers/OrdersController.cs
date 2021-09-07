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


    }
}
