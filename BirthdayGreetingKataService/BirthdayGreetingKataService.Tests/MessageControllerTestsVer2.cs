using BirthdayGreetingKataService.Controllers;
using BirthdayGreetingKataService.DataProviders;
using BirthdayGreetingKataService.GreetingMessageGenerators;
using BirthdayGreetingKataService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayGreetingKataService.Tests
{
    public class MessageControllerTestsVer2
    {
        [Theory]
        [MemberData(nameof(TestCases.GetDataForGenderFiltering), MemberType = typeof(TestCases))]
        public void FilterMembers_ReturnOk(string gender, List<Response> expectedResponses)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer2());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(null, null, gender);
            // assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValues = Assert.IsType<List<Response>>(okResult.Value);
        }

        [Theory]
        [MemberData(nameof(TestCases.GetDataForGenderFiltering), MemberType = typeof(TestCases))]
        public void FilterMembers_ReturnCorrectResult(string gender, List<Response> expectedResponses)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer2());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(null, null, gender);
            // assert
            var okResult = actionResult.Result as OkObjectResult;
            var returnValues = okResult.Value as List<Response>;
            int sameCount = 0;
            foreach (Response response in expectedResponses)
            {
                for (int i = 0; i < returnValues.Count; i++)
                {
                    if (response.Equals(returnValues[i]))
                    {
                        sameCount++;
                    }
                }
            }
            Assert.Equal(expectedResponses.Count, returnValues.Count);
            Assert.Equal(expectedResponses.Count, sameCount);
        }
    }
}
