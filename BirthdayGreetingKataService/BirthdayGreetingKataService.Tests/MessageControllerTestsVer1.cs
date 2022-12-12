using BirthdayGreetingKataService.Controllers;
using BirthdayGreetingKataService.DataProviders;
using BirthdayGreetingKataService.GreetingMessageGenerators;
using BirthdayGreetingKataService.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BirthdayGreetingKataService.Tests
{
    public class MessageControllerTestsVer1
    {
        [Theory]
        [MemberData(nameof(TestCases.GetDataForDateFiltering), MemberType = typeof(TestCases))]
        public void FilterMembers_PassExistedDate_ReturnOkAndCorrectResult(int month, int day, List<Response> expectedResult)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer1());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day);
            // assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValues = Assert.IsType<List<Response>>(okResult.Value);
        }

        [Theory]
        [MemberData(nameof(TestCases.GetDataForDateFiltering), MemberType = typeof(TestCases))]
        public void FilterMembers_PassExistedDate_ReturnCorrectResult(int month, int day, List<Response> expectedResult)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer1());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day);
            // assert
            var okResult = actionResult.Result as OkObjectResult;
            var returnValues = okResult.Value as List<Response>;
            int sameCount = 0;
            foreach (Response response in expectedResult)
            {
                for (int i = 0; i < returnValues.Count; i++)
                {
                    if (response.Equals(returnValues[i]))
                    {
                        sameCount++;
                    }
                }
            }
            Assert.Equal(expectedResult.Count, returnValues.Count);
            Assert.Equal(expectedResult.Count, sameCount);
        }
    }
}