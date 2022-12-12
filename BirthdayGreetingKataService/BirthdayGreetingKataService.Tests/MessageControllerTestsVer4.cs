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
    public class MessageControllerTestsVer4
    {
        [Theory]
        [MemberData(nameof(GetVer4DataForExistedDateFiltering))]
        public void FilterMembers_PassExistedDate_ReturnOk(int month, int day, List<Response> expected)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer4());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day, null, null);
            // assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnValues = Assert.IsType<List<Response>>(okResult.Value);
        }

        [Theory]
        [MemberData(nameof(GetVer4DataForExistedDateFiltering))]
        public void FilterMembers_PassExistedDate_ReturnCorrectResult(int month, int day, List<Response> expectedResult)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer4());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day, null, null);
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
        public void FilterMembers_PassNonExistedDate_ReturnNotFound(int month, int day, List<Response> expectedResult)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer4());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day, null, null);
            // assert
            var notfoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            var returnValues = Assert.IsType<List<Response>>(notfoundResult.Value);
        }

        [Theory]
        [MemberData(nameof(TestCases.GetDataForNonExistedDateFiltering), MemberType = typeof(TestCases))]
        public void FilterMembers_PassNonExistedDate_ReturnEmptyList(int month, int day, List<Response> expectedResult)
        {
            // arrange
            var messageController = new MessageController(new MockDataProvider(), new GreetingMessageGeneratorVer4());
            // act
            ActionResult<List<Response>> actionResult = messageController.FilterMembers(month, day, null, null);
            // assert
            var notFoundResult = actionResult.Result as NotFoundObjectResult;
            var returnValues = notFoundResult.Value as List<Response>;
            Assert.Empty(returnValues);
        }

        public static IEnumerable<object[]> GetVer4DataForExistedDateFiltering()
        {
            return new List<object[]>
            {
                new object[]
                {
                    8, 8, new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Yen, Robert!"),
                        new Response(Constants.MessageTitle, "Happy birthday, dear Chen, Sherry!")
                    }
                },
                new object[]
                {
                    10, 10, new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Change, Cid!")
                    }
                },
                new object[]
                {
                    4, 5, new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Lai, Miki!")
                    }
                },
                new object[]
                {
                    12, 22, new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Wang, Peter!")
                    }
                }
            };
        }


    }
}
