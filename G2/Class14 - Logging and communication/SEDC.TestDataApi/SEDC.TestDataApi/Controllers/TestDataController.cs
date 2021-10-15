using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.TestDataApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.TestDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDataController : ControllerBase
    {
        [HttpGet("testUser")]
        public ActionResult<User> GetTestUser()
        {
            return new User
            {
                FirstName = "Test",
                LastName = "User",
                Username = "testUser3",
                Password = "test123",
                ConfirmedPassword = "test123",
                Role = "Admin"
            };
        }
    }
}
