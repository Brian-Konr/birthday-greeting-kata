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
        [MemberData(nameof(TestCases.GetDataForExistedDateFiltering), MemberType = typeof(TestCases))]
        public void FilterMembers_PassExistedDate_ReturnOk(int month, int day, List<Response> expectedResult)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer1());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day, null);
            // assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValues = Assert.IsType<List<Response>>(okResult.Value);
        }

        [Theory]
        [MemberData(nameof(TestCases.GetDataForNonExistedDateFiltering), MemberType = typeof(TestCases))]
        public void FilterMembers_PassNonExistedDate_ReturnNotFound(int month, int day, List<Response> expectedResult)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer1());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day, null);
            // assert
            var notfoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            var returnValues = Assert.IsType<List<Response>>(notfoundResult.Value);
        }

        [Theory]
        [MemberData(nameof(TestCases.GetDataForExistedDateFiltering), MemberType = typeof(TestCases))]
        public void FilterMembers_PassExistedDate_ReturnCorrectResult(int month, int day, List<Response> expectedResult)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer1());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day, null);
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

        [Theory]
        [MemberData(nameof(TestCases.GetDataForNonExistedDateFiltering), MemberType = typeof(TestCases))]
        public void FilterMembers_PassNonExistedDate_ReturnEmptyList(int month, int day, List<Response> expectedResult)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer1());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day, null);
            // assert
            var notFoundResult = actionResult.Result as NotFoundObjectResult;
            var returnValues = notFoundResult.Value as List<Response>;
            Assert.Empty(returnValues);
        }
    }
}