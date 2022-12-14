using BirthdayGreetingKataService.DataProviders;
using BirthdayGreetingKataService.GreetingMessageGenerators;
using BirthdayGreetingKataService.Models;
using BirthdayGreetingKataService.ResultGenerators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using System.Data;
using System.Xml.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthdayGreetingKataService.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IDataProvider _dataProvider;

        private readonly IGreetingMessageGenerator _messageGenerator;

        private readonly IResultGenerator _resultGenerator;

        public MessageController(IDataProvider dataProvider, IGreetingMessageGenerator messageGenerator, IResultGenerator resultGenerator)
        {
            _dataProvider = dataProvider;
            _messageGenerator = messageGenerator;
            _resultGenerator = resultGenerator;
        }

        // GET: api/<MessageController>
        [HttpGet]
        [Route("search")]
        public ActionResult<List<Response>> FilterMembers(
            [FromQuery(Name = "month")] int? month,
            [FromQuery(Name = "day")] int? day,
            [FromQuery(Name = "gender")] string? gender,
            [FromQuery(Name = "isElder")] bool? isElder
        )
        {
            List<Member> selectedMembers = _dataProvider.FilterMembers(month, day, gender, isElder);
            List<Response> responses = selectedMembers.Select(member => _messageGenerator.GenerateGreetingMessage(member)).ToList();
            return _resultGenerator.GenerateResults(responses);
        }
    }
}
