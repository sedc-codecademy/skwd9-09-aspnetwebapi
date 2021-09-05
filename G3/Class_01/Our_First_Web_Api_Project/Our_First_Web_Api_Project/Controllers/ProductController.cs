using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Our_First_Web_Api_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private List<Product> Products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Coca Cola",
                BarCode = 12345678,
                Price = 30f
            },
            new Product()
            {
                Id = 2,
                Name = "Fanta",
                BarCode = 12345679,
                Price = 25f
            },
            new Product()
            {
                Id = 3,
                Name = "Sprite",
                BarCode = 123145678,
                Price = 30f
            }
        };
        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            return Products;
        }

        [HttpGet]
        [Route("product")]
        public Product GetById([FromQuery] int id)
        {
            Product product = Products.SingleOrDefault(product => product.Id == id);
            return product;
        }
    }
}
