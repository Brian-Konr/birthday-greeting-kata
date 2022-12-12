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
        public static IEnumerable<object[]> GetDataForGenderFiltering()
        {
            return new List<object[]>
            {
                new object[]
                {
                    "Male", new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Robert!\nWe offer special discount 20% off for the following items:\nWhite Wine, iPhone X"),
                        new Response(Constants.MessageTitle, "Happy birthday, dear Peter!\nWe offer special discount 20% off for the following items:\nWhite Wine, iPhone X"),
                        new Response(Constants.MessageTitle, "Happy birthday, dear Cid!\nWe offer special discount 20% off for the following items:\nWhite Wine, iPhone X")
                    }
                },
                new object[]
                {
                    "Female", new List<Response>
                    {
                        new Response(Constants.MessageTitle, "Happy birthday, dear Miki!\nWe offer special discount 50% off for the following items:\nCosmetic, LV Handbags"),
                        new Response(Constants.MessageTitle, "Happy birthday, dear Sherry!\nWe offer special discount 50% off for the following items:\nCosmetic, LV Handbags"),
                    }
                },
            };
        }

    }
}
