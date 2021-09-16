using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private BookDbContext _dbContext;

        public ValuesController()
        {
            _dbContext = new BookDbContext();
        }

        [HttpGet("")]
        public ActionResult Index()
        {
            return StatusCode(StatusCodes.Status200OK, _dbContext.Authors.ToList());
        }
    }
}
