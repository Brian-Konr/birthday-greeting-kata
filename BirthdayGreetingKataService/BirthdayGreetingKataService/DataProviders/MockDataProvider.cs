using BirthdayGreetingKataService.Models;
using System.Globalization;

namespace BirthdayGreetingKataService.DataProviders
{
    public class MockDataProvider : IDataProvider
    {
        public List<Member> FilterMembers(int? month, int? day, string? gender, bool? isElder)
        {
            List<Member> filteredMembers = GenerateAllMembers();
            if (month != null)
            {
                filteredMembers = filteredMembers.Where(member => member.DateofBirth.Month == month).ToList();
            }
            if (day != null)
            {
                filteredMembers = filteredMembers.Where(member => member.DateofBirth.Day == day).ToList();
            }
            return filteredMembers;
        }

        private List<Member> GenerateAllMembers()
        {
            return new List<Member>
            {
                new Member(
                    firstName: "Robert",
                    lastName: "Yen",
                    gender: "Male",
                    dateofBirth: GenerateDateTimeFromString("1985/08/08"),
                    email: "robert.yen@linecorp.com"
                ),
                new Member(
                    firstName: "Cid",
                    lastName: "Change",
                    gender: "Male",
                    dateofBirth: GenerateDateTimeFromString("1990/10/10"),
                    email: "cid.change@linecorp.com"
                ),
                new Member(
                    firstName: "Miki",
                    lastName: "Lai",
                    gender: "Female",
                    dateofBirth: GenerateDateTimeFromString("1993/04/05"),
                    email: "miki.lai@linecorp.com"
                ),
                new Member(
                    firstName: "Sherry",
                    lastName: "Chen",
                    gender: "Female",
                    dateofBirth: GenerateDateTimeFromString("1993/08/08"),
                    email: "sherry.lai@linecorp.com"
                ),
                new Member(
                    firstName: "Peter",
                    lastName: "Wang",
                    gender: "Male",
                    dateofBirth: GenerateDateTimeFromString("1950/12/22"),
                    email: "peter.wang@linecorp.com"
                )
            };
        }
        private DateTime GenerateDateTimeFromString(string date)
        {
            return DateTime.ParseExact(
                date,
                "yyyy/MM/dd",
                CultureInfo.InvariantCulture
            );
        }
    }
}
