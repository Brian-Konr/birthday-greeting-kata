using BirthdayGreetingKataService.Models;
using System.Globalization;

namespace BirthdayGreetingKataService.DataProviders
{
    public class MockDataProvider : IDataProvider
    {
        public List<Member> FilterMembers(int? month, int? day, string? gender, bool? isElder)
        {
            List<Member> filteredMembers = Utils.GenerateAllMembers();
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
                filteredMembers = filteredMembers.Where(member => Utils.GetAgeFromDateofBirth(member.DateofBirth) > Constants.ElderThreshold).ToList()
;           }
            return filteredMembers;
        }
    }
}
