using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication4.Controllers
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

        [HttpGet]
        public ActionResult Index()
        {
            var books = _dbContext.Books.Include(x => x.Author).ToList();
            return StatusCode(StatusCodes.Status200OK, books);
        }
    }
}
