using BirthdayGreetingKataService.DataProviders;
using BirthdayGreetingKataService.GreetingMessageGenerators;
using BirthdayGreetingKataService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthdayGreetingKataService.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IDataProvider _dataProvider;

        private readonly IGreetingMessageGenerator _messageGenerator;
        public MessageController(IDataProvider dataProvider, IGreetingMessageGenerator messageGenerator)
        {
            _dataProvider = dataProvider;
            _messageGenerator = messageGenerator;
        }

        // GET: api/<MessageController>
        [HttpGet]
        [Route("search")]
        public ActionResult<List<Response>> FilterMembers(
            [FromQuery(Name = "month")] int? month,
            [FromQuery(Name = "day")] int? day,
            [FromQuery(Name = "gender")] string? gender
        )
        {
            List<Member> selectedMembers = _dataProvider.FilterMembers(month, day, gender, null);
            List<Response> responses = selectedMembers.Select(member => _messageGenerator.GenerateGreetingMessage(member)).ToList();
            return responses.Count > 0 ? Ok(responses) : NotFound(responses);
        }
    }
}
