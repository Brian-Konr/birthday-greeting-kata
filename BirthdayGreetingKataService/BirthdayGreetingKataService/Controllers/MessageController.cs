using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthdayGreetingKataService.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        // GET: api/<MessageController>
        [HttpGet]
        public IEnumerable<string> Get(
            [FromQuery(Name = "month")] int month,
            [FromQuery(Name = "day")] int day
        )
        {
            return new string[] { "value1", "value2" };
        }
    }
}
