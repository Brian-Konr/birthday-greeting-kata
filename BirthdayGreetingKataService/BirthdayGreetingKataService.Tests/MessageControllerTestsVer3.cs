using BirthdayGreetingKataService.Controllers;
using BirthdayGreetingKataService.DataProviders;
using BirthdayGreetingKataService.GreetingMessageGenerators;
using BirthdayGreetingKataService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayGreetingKataService.Tests
{
    public class MessageControllerTestsVer3
    {
        [Fact]
        public void FilterMembers_Elder_ReturnOK()
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer3());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(null, null, null, true);
            // assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValues = Assert.IsType<List<Response>>(okResult.Value);
        }

        [Fact]
        public void FilterMembers_Elder_ReturnCorrectResult()
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer3());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(null, null, null, true);
            // assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValues = Assert.IsType<List<Response>>(okResult.Value);

            var expected = new Response(Constants.MessageTitle, "Happy birthday, dear `Peter`!\n(A greeting picture here)\n");
            Assert.True(expected.Equals(returnValues.First()));
        }
    }
}
