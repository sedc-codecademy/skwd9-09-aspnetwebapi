using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.Orders.DAL.Context;
using SEDC.Orders.DAL.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Orders.Entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersDbContext _ordersDb;

        public OrdersController(OrdersDbContext ordersDb)
        {
            _ordersDb = ordersDb;
        }

        //THIS IS FOR DEMO, DO NOT USE DB CONTEXT INSIDE A CONTROLLER!

        [HttpPost]
        [Route("CreateOrder")]
        public IActionResult CreateOrder([FromBody] Order order) 
        {
            order.OrderCreationDate = DateTime.Now;

            _ordersDb.Orders.Add(order);
            _ordersDb.SaveChanges();

            return Ok("Order succesfully added to the database!");
        }

        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetAllOrders() 
        {
            var orders = _ordersDb.Orders.ToList();
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetOrderById/id/{id}")]
        public IActionResult GetOrderById([FromRoute] int id) 
        {
            var order = _ordersDb.Orders.SingleOrDefault(o => o.Id == id);
            return Ok(order);
        }

        [HttpDelete]
        [Route("DeleteOrderById/id/{id}")]
        public IActionResult DeleteOrderById([FromRoute] int id)
        {
            var order = _ordersDb.Orders.SingleOrDefault(o => o.Id == id);

            _ordersDb.Orders.Remove(order);
            _ordersDb.SaveChanges();

            return Ok("Order succesfully deleted!");
        }


        [HttpPut]
        [Route("UpdateOrder")]
        public IActionResult UpdateOrder([FromBody] Order order) 
        {
            order.OrderCreationDate = DateTime.Now;

            _ordersDb.Orders.Update(order);
            _ordersDb.SaveChanges();
           
            return Ok("Order succesfully updated!");
        }

        

    }
}
