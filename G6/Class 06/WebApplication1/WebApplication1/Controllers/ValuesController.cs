using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private BookDbContext _dbContext;

        public ValuesController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("")]
        public ActionResult Index()
        {
            return StatusCode(StatusCodes.Status200OK, _dbContext.Authors.ToList());
        }
    }
}
