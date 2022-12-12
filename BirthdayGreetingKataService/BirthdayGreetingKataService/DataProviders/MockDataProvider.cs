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
            if (gender != null)
            {
                filteredMembers = filteredMembers.Where(member => member.Gender.Equals(gender)).ToList();
            }
            if (isElder != null && isElder.Value) 
            {
                filteredMembers = filteredMembers.Where(member => GetAgeFromDateofBirth(member.DateofBirth) > Constants.ElderThreshold).ToList()
;           }
            return filteredMembers;
        }

        public static List<Member> GenerateAllMembers()
        {
            return new List<Member>
            {
                new Member(
                    firstName: "Robert",
                    lastName: "Yen",
                    gender: "Male",
                    dateofBirth: new DateTime(1985, 8, 8),
                    email: "robert.yen@linecorp.com"
                ),
                new Member(
                    firstName: "Cid",
                    lastName: "Change",
                    gender: "Male",
                    dateofBirth: new DateTime(1990, 10, 10),
                    email: "cid.change@linecorp.com"
                ),
                new Member(
                    firstName: "Miki",
                    lastName: "Lai",
                    gender: "Female",
                    dateofBirth: new DateTime(1993, 4, 5),
                    email: "miki.lai@linecorp.com"
                ),
                new Member(
                    firstName: "Sherry",
                    lastName: "Chen",
                    gender: "Female",
                    dateofBirth: new DateTime(1993, 8, 8),
                    email: "sherry.lai@linecorp.com"
                ),
                new Member(
                    firstName: "Peter",
                    lastName: "Wang",
                    gender: "Male",
                    dateofBirth: new DateTime(1950, 12, 22),
                    email: "peter.wang@linecorp.com"
                )
            };
        }

        private int GetAgeFromDateofBirth(DateTime dateofBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateofBirth.Year - 1;
            if (today.Month < dateofBirth.Month || (today.Month == dateofBirth.Month && today.Day <= dateofBirth.Day))
            {
                age++;
            }
            return age;
        }
    }
}
