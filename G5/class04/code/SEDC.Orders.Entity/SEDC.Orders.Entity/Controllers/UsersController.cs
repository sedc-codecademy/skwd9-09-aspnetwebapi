using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEDC.Orders.DAL.Context;
using SEDC.Orders.DAL.DomainModels;
using SEDC.Orders.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Orders.Entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly OrdersDbContext _ordersDb;

        public UsersController(OrdersDbContext ordersDb)
        {
            _ordersDb = ordersDb;
        }

        //THIS IS FOR DEMO, DO NOT USE DB CONTEXT INSIDE A CONTROLLER!


        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateUser([FromBody] UserWithInfoRequestModel requestModel) 
        {
            var user = new User()
            {
                FullName = requestModel.FullName,
                Username = requestModel.Username,
                Password = requestModel.Password
            };

            var response = _ordersDb.Users.Add(user);
            _ordersDb.SaveChanges();

            var userInfo = new UserInfo()
            {
                FavouriteFood = requestModel.FavouriteFood,
                NumberOfOrders = requestModel.NumberOfOrders,
                UserId = response.Entity.Id
            };

            _ordersDb.UserInfos.Add(userInfo);
            _ordersDb.SaveChanges();

            return Ok("User succesfully created!");
        }


        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser() 
        {

            var user = _ordersDb.Users.FirstOrDefault(x => x.Id == 1);


            user.Orders = new List<Order>()
            {
                new Order()
                {
                    Address = "some random address",
                    IsDelievered = false,
                    OrderCreationDate = DateTime.Now,
                    OrderNumber = 11111,
                    UserId = user.Id
                },
                new Order()
                {
                    Address = "some random address",
                    IsDelievered = true,
                    OrderCreationDate = DateTime.Now,
                    OrderNumber = 11112,
                    UserId = user.Id
                },
            };

            _ordersDb.Users.Update(user);
            _ordersDb.SaveChanges();

            return Ok("User sucesfully updated!");
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers() 
        {
            var users = _ordersDb.Users.Include(x => x.Orders)
                                       .ThenInclude(x => x.OrderProducts)
                                       .ThenInclude(x => x.Product)
                                       .Include(x => x.UserInfo)
                                       .ToList();
            return Ok(users);        
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser()
        {
            var user = _ordersDb.Users.FirstOrDefault(x => x.Id == 1);

            _ordersDb.Users.Remove(user);
            _ordersDb.SaveChanges();

            return Ok("User succesfully deleted!");
        }

    }
}
