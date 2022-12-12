using BirthdayGreetingKataService.DataProviders;
using BirthdayGreetingKataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayGreetingKataService.Tests
{
    internal class TestCases
    {

        public static IEnumerable<object[]> GetDataForDateFiltering()
        {
            return new List<object[]>
            {
                new object[]
                {
                    8, 8, new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Robert!"),
                        new Response(Constants.MessageTitle, "Happy birthday, dear Sherry!")
                    }
                },
                new object[]
                {
                    10, 10, new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Cid!")
                    }
                },
                new object[]
                {
                    4, 5, new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Miki!")
                    }
                },
                new object[]
                {
                    12, 22, new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Peter!")
                    }
                }
            };
        }
    }
}
